using System;
using Xamarin.Forms;
using System.Diagnostics;
using EnixerBanks;
using EnixerBanks.Droid;
using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using Android.Graphics;
using System.IO;
using Plugin.CurrentActivity;

using Android.Content;
using Environment = Android.OS.Environment;
using Android.Icu.Text;
using Java.Util;

[assembly: Dependency(typeof(SavePicServices))]
namespace EnixerBanks.Droid
{
    public class SavePicServices : EnixerBanks.ISavePic
    {
        //static String strSDCardPathName = Environment.get(Environment.DirectoryPictures) + "/temp_picture" + "/";


        public Task<bool> Save(string path, string _name)
        {
            var result = new TaskCompletionSource<bool>();

            //var d = Xamarin.Essentials.FileSystem.CacheDirectory;

            //var dir = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim);
            //var pictures = dir.AbsolutePath;
            ////adding a time stamp time file name to allow saving more than one image... otherwise it overwrites the previous saved image of the same name
            //string name = "MY_QR" + System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
            //string filePath = System.IO.Path.Combine(pictures, name);

            //System.IO.File.WriteAllBytes(filePath, imageData);
            //File.SetAttributes(filePath, FileAttributes.Normal);
            ////mediascan adds the saved image into the gallery
            var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            mediaScanIntent.SetData(Android.Net.Uri.FromFile(new Java.IO.File(path)));

            Xamarin.Forms.Forms.Context.SendBroadcast(mediaScanIntent);

            result.SetResult(true);
            //createImageFile();
            //GalleryAddPic();


            //var _filename = _name;

            //if (_filename.ToLower().Contains(".jpg") || _filename.ToLower().Contains(".png"))
            //{
            //stream.Position = 0;
            //var bitmap = BitmapFactory.DecodeStream(stream);

            //var finalStream = new MemoryStream();

            //bitmap.Compress(Bitmap.CompressFormat.Jpeg, 25, finalStream);
            //bitmap = null;


            //finalStream.Position = 0;


            //Console.WriteLine(Android.OS.Environment.DirectoryPictures);
            //var path3 = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            //var path2 = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures);


            //var filename2 = System.IO.Path.Combine(path2.AbsolutePath, _filename);


            //Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);


            //Java.IO.File f = new Java.IO.File.
            //Android.Net.Uri contentUri = Android.Net.Uri.FromFile(f);
            //mediaScanIntent.SetData(contentUri);

            //Android.App.Application.Context.SendBroadcast(mediaScanIntent);



            //using (var fileStream = File.Create(filename2))
            //{
            //    finalStream.Seek(0, SeekOrigin.Begin);
            //    finalStream.CopyTo(fileStream);
            //    fileStream.Close();

            //    finalStream.Dispose();
            //    stream.Dispose();
            //    fileStream.Dispose();
            //    GC.Collect();
            //}
            //    return;
            //}

            return result.Task;

        }


        //private Java.IO.File createImageFile()
        //{
        //    // Create an image file name
        //    String timeStamp = new SimpleDateFormat("yyyyMMdd_HHmmss").Format(new Date());
        //    String imageFileName = "JPEG_" + timeStamp + "_";
        //    Java.IO.File storageDir = new Java.IO.File(strSDCardPathName);
        //    Java.IO.File image = Java.IO.File.CreateTempFile(
        //    imageFileName,  /* prefix */
        //    ".jpg",         /* suffix */
        //    storageDir      /* directory */
        //);

        //    // Save a file: path for use with ACTION_VIEW intents
        //    mCurrentPhotoPath = image.AbsolutePath;
        //    return image;
        //}

        //private void GalleryAddPic()
        //{
        //    Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
        //    Java.IO.File f = new Java.IO.File(mCurrentPhotoPath);
        //    Android.Net.Uri contentUri = Android.Net.Uri.FromFile(f);
        //    mediaScanIntent.SetData(contentUri);
        //    Android.App.Application.Context.SendBroadcast(mediaScanIntent);
        //}

    }
}
