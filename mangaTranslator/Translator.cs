using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;

public class Translator
{

    bool isDone = false;
    void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        if(e.ProgressPercentage == 100)
        {
            isDone = true;
        }
    }
    public async Task<string> TranslateAsync(string sourceText, string sourceLanguage, string targetLanguage)
    {
        string translation = string.Empty;

        try
        {
            // Download translation
            string url = string.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
                                        sourceLanguage,
                                        targetLanguage,
                                        HttpUtility.UrlEncode(sourceText));
            string outputFile = Path.GetTempFileName();
     
            using (WebClient wc = new WebClient())
            {
                
                 wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(new Uri(url), outputFile );
            }
            while (!isDone) { await Task.Delay(100); }
            if (File.Exists(outputFile))
            {
                string text = File.ReadAllText(outputFile);
                translation = text.Remove(0, 4);
                translation = translation.Substring(0, translation.IndexOf("\""));

            }
            File.Delete(outputFile);
        }
        catch { }
        return translation;
    }



}
