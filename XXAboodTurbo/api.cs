using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic;
using System.Collections;
using System.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;

namespace XXAboodTurbo
{
    internal sealed class api
    {
        public static string String0 = string.Empty;
        public static string String31 = string.Empty;
        public static string String1 = string.Empty;
        public static string String2 = string.Empty;
        public static string String3 = string.Empty;
        public static string String4 = string.Empty;
        public static string String5 = string.Empty;
        public static string String6 = string.Empty;
        public static string String7 = string.Empty;
        public static string cGbvuvYpu = string.Empty;
        public static string String8 = "i.instagram.com";
        public static string String9 = "Instagram 20.6.4 Android (18/4.3; 480dpi; 1080x1812; HUAWEI; HUAWEI VNS-L31; HWVNS-H; hi6250; es_ES)";
        public static string String10 = "Instagram 20.6.4 Android (18/4.3; 480dpi; 1080x1812; HUAWEI; HUAWEI VNS-L31; HWVNS-H; hi6250; es_ES)";
        public static string String11 = "5ad7d6f013666cc93c88fc8af940348bd067b68f0dce3c85122a923f4f74b251";
        public static string String12 = "fc4720e1bf9d79463f62608c86fbddd374cc71bbfb98216b52e3f75333bd130d";
        public static CookieContainer cookieContainer_0 = new CookieContainer();
        public static string String13 = string.Empty;
        public static string String14 = "https://i.instagram.com/api/v1/";
        public static string String15 = Guid.NewGuid().ToString().ToUpper();
        public static object Method(object object_0, object object_1)
        {
            object obj = (object)false;
            StringBuilder stringBuilder_0 = new StringBuilder();
            string String16 = "{\"_uuid\":\"" + Guid.NewGuid().ToString().ToUpper() + "\",\"password\":\"" + Conversions.ToString(RuntimeHelpers.GetObjectValue(object_1)) + "\",\"username\":\"" + Conversions.ToString(RuntimeHelpers.GetObjectValue(object_0)) + "\",\"device_id\":\"" + Guid.NewGuid().ToString().ToUpper() + "\",\"from_reg\":false,\"_csrftoken\":\"missing\",\"login_attempt_count\":0}";
            string str1 = string.Format("{0}.{1}", (object)api.Method4(String16, api.String12), (object)String16);
            stringBuilder_0.AppendLine("--" + api.String15);
            stringBuilder_0.AppendLine("Content-Disposition: form-data; name=\"signed_body\"");
            stringBuilder_0.AppendLine();
            stringBuilder_0.AppendLine(str1);
            stringBuilder_0.AppendLine("--" + api.String15);
            stringBuilder_0.AppendLine("Content-Disposition: form-data; name=\"ig_sig_key_version\"");
            stringBuilder_0.AppendLine();
            stringBuilder_0.AppendLine("4");
            stringBuilder_0.Append("--" + api.String15 + "--");
            string str2 = api.Method1(stringBuilder_0);
            if (str2.Contains("logged_in_user"))
                obj = (object)true;
            else if (str2.Contains("checkpoint_required"))
            {
                int num1 = (int)Interaction.MsgBox((object)"Please Confirm Email/number Phone and try again", MsgBoxStyle.Critical, (object)"Secure");
            }
            else
            {
                int num2 = (int)Interaction.MsgBox((object)"Incorrect Username or Password ,  Please check your username/password and try again", MsgBoxStyle.Critical, (object)"Incorrect Info");
            }
            if (str2.Contains("The username you entered doesn't appear to belong to an account. Please check your username and try again."))
            {
                int num3 = (int)Interaction.MsgBox((object)"The username you entered doesn't appear to belong to an account. Please check your username and try again.", MsgBoxStyle.Critical, (object)"incorrect username");
            }
            if (str2.Contains("The password you entered is incorrect. Please try again"))
            {
                int num4 = (int)Interaction.MsgBox((object)"The password you entered is incorrect. Please try again", MsgBoxStyle.Critical, (object)"Passowrd incorrect");
            }
            return obj;
        }

        public static string Method1(StringBuilder stringBuilder_0)
        {
            string str = (string)null;
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(stringBuilder_0.ToString());
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(api.String14 + "accounts/login/");
                httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
                httpWebRequest.Method = "POST";
                httpWebRequest.Host = api.String8;
                httpWebRequest.UserAgent = api.String10;
                httpWebRequest.Headers.Add("Accept-Language", "en;q=0.9");
                httpWebRequest.KeepAlive = true;
                httpWebRequest.Proxy = (IWebProxy)null;
                httpWebRequest.ContentType = "multipart/form-data; boundary=" + api.String15;
                httpWebRequest.ContentLength = (long)bytes.Length;
                httpWebRequest.CookieContainer = api.cookieContainer_0;
                Stream requestStream = httpWebRequest.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                    str = streamReader.ReadToEnd();
                try
                {
                    try
                    {
                        try
                        {
                            IEnumerator enumerator;
                            try
                            {
                                enumerator = response.Cookies.GetEnumerator();
                                while (enumerator.MoveNext())
                                {
                                    object objectValue = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(enumerator.Current))))))))))))))))))));
                                    api.String13 = api.String13 + objectValue.ToString() + ";";
                                }
                            }
                            finally
                            {
                               // if (enumerator is IDisposable)
                                   // (enumerator as IDisposable).Dispose();
                            }
                        }
                        finally
                        {
                            //IEnumerator enumerator;
                            //if (api.GetEnumerator(enumerator) is IDisposable)
                              //  (enumerator as IDisposable).Dispose();
                        }
                    }
                    finally
                    {
                        IEnumerator enumerator;
                        //if (enumerator is IDisposable)
                           // (enumerator as IDisposable).Dispose();
                    }
                }
                finally
                {
                }
                response.Close();
            }
            catch (WebException ex)
            {
                ProjectData.SetProjectError((Exception)ex);
                using (StreamReader streamReader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    str = streamReader.ReadToEnd();
                    streamReader.Close();
                }
                ProjectData.ClearProjectError();
            }
            return str;
        }

        private static IEnumerator GetEnumerator(IEnumerator enumerator)
        {
            return enumerator;
        }

        public static object Method2(CookieContainer cookieContainer_1)
        {
            object obj = (object)false;
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes("");
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(api.String14 + "accounts/logout/");
                httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
                httpWebRequest.Method = "POST";
                httpWebRequest.Host = api.String8;
                httpWebRequest.UserAgent = api.String10;
                httpWebRequest.Headers.Add("Accept-Language", "en;q=0.9");
                httpWebRequest.KeepAlive = true;
                httpWebRequest.Proxy = (IWebProxy)null;
                httpWebRequest.ContentLength = (long)bytes.Length;
                httpWebRequest.CookieContainer = cookieContainer_1;
                Stream requestStream = httpWebRequest.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                {
                    int num = (int)Interaction.MsgBox((object)streamReader.ReadToEnd(), MsgBoxStyle.OkOnly, (object)null);
                    if (streamReader.ReadToEnd().Contains("{\"status\": \"ok\"}"))
                        obj = (object)true;
                    streamReader.Close();
                }
                response.Close();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                obj = (object)false;
                ProjectData.ClearProjectError();
            }
            return obj;
        }

        public static object Method3()
        {
            object obj = (object)false;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://i.instagram.com/api/v1/accounts/current_user/?edit=true");
            httpWebRequest.Method = "GET";
            httpWebRequest.KeepAlive = true;
            httpWebRequest.UserAgent = api.String9;
            httpWebRequest.Proxy = (IWebProxy)null;
            httpWebRequest.CookieContainer = api.cookieContainer_0;
            try
            {
                using (StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream()))
                {
                    string end = streamReader.ReadToEnd();
                    api.String0 = Regex.Match(end, "pk\": (.*?),").Groups[1].Value;
                    api.String5 = Regex.Match(end, "email\": \"(.*?)\"").Groups[1].Value;
                    api.String3 = Regex.Match(end, "phone_number\": \"(.*?)\"").Groups[1].Value;
                    obj = (object)true;
                }
            }
            catch (WebException ex)
            {
                ProjectData.SetProjectError((Exception)ex);
                WebException webException = ex;
                obj = (object)false;
                using (new StreamReader(webException.Response.GetResponseStream()))
                    ;
                ProjectData.ClearProjectError();
            }
            return obj;
        }

        public static string Method4(string String16, string String17)
        {
            int num1 = 0;
            StringBuilder stringBuilder = new StringBuilder();
            HMACSHA256 hmacshA256 = new HMACSHA256(Encoding.UTF8.GetBytes(String17));
            hmacshA256.ComputeHash(Encoding.UTF8.GetBytes(String16));
            byte[] hash = hmacshA256.Hash;
            int num2 = checked(hash.Length - 1);
            for (int index = 0; index <= num1; num1 = num2)
            {
                byte num3 = hash[index];
                stringBuilder.Append(num3.ToString("x2"));
                checked { ++index; }
            }
            return stringBuilder.ToString();
        }
    }
}
