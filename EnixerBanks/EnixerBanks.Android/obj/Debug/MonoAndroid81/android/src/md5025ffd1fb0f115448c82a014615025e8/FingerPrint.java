package md5025ffd1fb0f115448c82a014615025e8;


public class FingerPrint
	extends android.support.v4.hardware.fingerprint.FingerprintManagerCompat.AuthenticationCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAuthenticationSucceeded:(Landroid/support/v4/hardware/fingerprint/FingerprintManagerCompat$AuthenticationResult;)V:GetOnAuthenticationSucceeded_Landroid_support_v4_hardware_fingerprint_FingerprintManagerCompat_AuthenticationResult_Handler\n" +
			"";
		mono.android.Runtime.register ("EnixerBanks.Droid.FingerPrint, EnixerBanks.Android", FingerPrint.class, __md_methods);
	}


	public FingerPrint ()
	{
		super ();
		if (getClass () == FingerPrint.class)
			mono.android.TypeManager.Activate ("EnixerBanks.Droid.FingerPrint, EnixerBanks.Android", "", this, new java.lang.Object[] {  });
	}


	public void onAuthenticationSucceeded (android.support.v4.hardware.fingerprint.FingerprintManagerCompat.AuthenticationResult p0)
	{
		n_onAuthenticationSucceeded (p0);
	}

	private native void n_onAuthenticationSucceeded (android.support.v4.hardware.fingerprint.FingerprintManagerCompat.AuthenticationResult p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
