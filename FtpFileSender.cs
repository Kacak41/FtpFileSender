using System;
using System.IO;
using System.Net;
using System.Text;

public class FtpFileSender
{
        private string FileName="", LocalPath="", ServerPath="", User="", Pass="", Server="";
        public FtpFileSender()
        {
        }
        public FtpFileSender(String FileName, String LocalPath, String Server, String ServerPath, String User, String Pass)
        {
            this.FileName = FileName;
            this.LocalPath = LocalPath;
            this.Server = Server;
            this.ServerPath = ServerPath;
            this.User = User;
            this.Pass = Pass;
        }
        public void setFileName(String FileName){
            this.FileName=FileName;
        }
        public void setLocalPath(String LocalPath)
        {
            this.LocalPath = LocalPath;
        }
        public void setServerPath(String ServerPath)
        {
            this.ServerPath = ServerPath;
        }
        public void setUser(String User){
            this.User=User;
        }
        public void setPass(String Pass)
        {
            this.Pass = Pass;
        }
        public void setServer(String Server)
        {
            this.Server = Server;
        }
        public string SendFile()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(this.Server+this.ServerPath+this.FileName);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            
            request.Credentials = new NetworkCredential(this.User, this.Pass);

            
            StreamReader sourceStream = new StreamReader(this.LocalPath+this.FileName);
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            string responses=response.StatusDescription;

            response.Close();
            return "Upload File Complete, status " + responses;
        }
	}

