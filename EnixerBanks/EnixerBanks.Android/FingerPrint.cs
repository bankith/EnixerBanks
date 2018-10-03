using System;
using Xamarin.Forms;
using System.Diagnostics;
using EnixerBanks;
using EnixerBanks.Droid;
using Android.Support.V4.Hardware.Fingerprint;
using Android.Hardware.Fingerprints;
using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using Res = Android.Resource;
using Android.Security.Keystore;
using Java.Security;
using Javax.Crypto;
using System.Threading.Tasks;

[assembly: Dependency(typeof(FingerPrint))]
namespace EnixerBanks.Droid
{
    public class FingerPrint : FingerprintManagerCompat.AuthenticationCallback, IScanFinger
    {

        // ReSharper disable InconsistentNaming
        static readonly string TAG = "X:" + typeof(FingerPrint).Name;
        static readonly string DIALOG_FRAGMENT_TAG = "fingerprint_auth_fragment";
        static readonly int ERROR_TIMEOUT = 250;
        private TaskCompletionSource<bool> tcs;
        // ReSharper restore InconsistentNaming
        bool _canScan;

        public FingerPrint()
        {
        }


        public Task<bool> Scan()
        {

            tcs = new TaskCompletionSource<bool>();
            var Context = Android.App.Application.Context;
            // Using the Android Support Library v4
            FingerprintManagerCompat fingerprintManager = FingerprintManagerCompat.From(Context);


            if (!fingerprintManager.IsHardwareDetected)
            {
                Toast.MakeText(Context, "FingerPrint authentication permission not enable", ToastLength.Short).Show();
                tcs.SetResult(false);
                return tcs.Task;
            }

            if (!fingerprintManager.HasEnrolledFingerprints)
                Toast.MakeText(Context, "Register at least one fingerprint in Settings", ToastLength.Short).Show();
            else
            {



                const int flags = 0; /* always zero (0) */

                // CryptoObjectHelper is described in the previous section.
                CryptoObjectHelper cryptoHelper = new CryptoObjectHelper();

                // cancellationSignal can be used to manually stop the fingerprint scanner. 
                var cancellationSignal = new Android.Support.V4.OS.CancellationSignal();


                // AuthenticationCallback is a base class that will be covered later on in this guide.
                //FingerprintManagerCompat.AuthenticationCallback authenticationCallback = new MyAuthCallbackSample(this);

                // Start the fingerprint scanner.
                fingerprintManager.Authenticate(cryptoHelper.BuildCryptoObject(), flags, cancellationSignal, this, null);

                Toast.MakeText(Context, "Put your finger to scan", ToastLength.Short).Show();
            }

            return tcs.Task;

        }


        public override void OnAuthenticationSucceeded(FingerprintManagerCompat.AuthenticationResult result)
        {
            base.OnAuthenticationSucceeded(result);
            Console.WriteLine("OK");
            tcs.SetResult(true);

        }




    }

    public class CryptoObjectHelper
    {
        // This can be key name you want. Should be unique for the app.
        static readonly string KEY_NAME = "com.xamarin.android.sample.fingerprint_authentication_key";

        // We always use this keystore on Android.
        static readonly string KEYSTORE_NAME = "AndroidKeyStore";

        // Should be no need to change these values.
        static readonly string KEY_ALGORITHM = KeyProperties.KeyAlgorithmAes;
        static readonly string BLOCK_MODE = KeyProperties.BlockModeCbc;
        static readonly string ENCRYPTION_PADDING = KeyProperties.EncryptionPaddingPkcs7;
        static readonly string TRANSFORMATION = KEY_ALGORITHM + "/" +
                                                BLOCK_MODE + "/" +
                                                ENCRYPTION_PADDING;
        readonly KeyStore _keystore;

        public CryptoObjectHelper()
        {
            _keystore = KeyStore.GetInstance(KEYSTORE_NAME);
            _keystore.Load(null);
        }

        public FingerprintManagerCompat.CryptoObject BuildCryptoObject()
        {
            Cipher cipher = CreateCipher();
            return new FingerprintManagerCompat.CryptoObject(cipher);
        }

        Cipher CreateCipher(bool retry = true)
        {
            IKey key = GetKey();
            Cipher cipher = Cipher.GetInstance(TRANSFORMATION);
            try
            {
                cipher.Init(CipherMode.EncryptMode | CipherMode.DecryptMode, key);
            }
            catch (KeyPermanentlyInvalidatedException e)
            {
                _keystore.DeleteEntry(KEY_NAME);
                if (retry)
                {
                    CreateCipher(false);
                }
                else
                {
                    throw new Exception("Could not create the cipher for fingerprint authentication.", e);
                }
            }
            return cipher;
        }

        IKey GetKey()
        {
            IKey secretKey;
            if (!_keystore.IsKeyEntry(KEY_NAME))
            {
                CreateKey();
            }

            secretKey = _keystore.GetKey(KEY_NAME, null);
            return secretKey;
        }

        void CreateKey()
        {
            KeyGenerator keyGen = KeyGenerator.GetInstance(KeyProperties.KeyAlgorithmAes, KEYSTORE_NAME);
            KeyGenParameterSpec keyGenSpec =
                new KeyGenParameterSpec.Builder(KEY_NAME, KeyStorePurpose.Encrypt | KeyStorePurpose.Decrypt)
                    .SetBlockModes(BLOCK_MODE)
                    .SetEncryptionPaddings(ENCRYPTION_PADDING)
                    .SetUserAuthenticationRequired(true)
                    .Build();
            keyGen.Init(keyGenSpec);
            keyGen.GenerateKey();
        }
    }
}
