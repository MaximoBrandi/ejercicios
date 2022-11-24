using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace ConsoleApplication1
{
    public class FileSystem
    {
        private IDictionary<string, string> _listado = new Dictionary<string, string>();
        private IDictionary<string, string> _cache = new Dictionary<string, string>();

        private string _line;
        private string _employee;

        public void Inicio(bool temporaryFiles)
        {
            switch (temporaryFiles)
            {
                case true:
                    try
                    {
                        if (File.Exists(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\Working\Ex12.2\Listado.txt"))
                        {
                            cargarListadoCache(true);
                            escribirCache(true);
                            cargarCache();
                        }
                        else
                        {
                            Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\Working\Ex12.2");
                            Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\Working\Ex12.2\Lists\");
                            File.Create(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\Working\Ex12.2\Listado.txt");
                            File.Create(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\cache.txt");
                            
                            escribirCache(false);
                            cargarCache();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    break;
                case false:
                    try
                    {
                        if (File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\Working\Ex12.2\Listado.txt"))
                        {
                            cargarListadoCache(false);
                            escribirCache(false);
                            cargarCache();
                        }
                        else
                        {
                            Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\Working\Ex12.2");
                            Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\Working\Ex12.2\Lists\");
                            File.Create(@"C:\Users\" + Environment.UserName + @"\Documents\Working\Ex12.2\Listado.txt").Close();
                            File.Create(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\cache.txt").Close();
                            
                            escribirCache(false);
                            cargarCache();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    break;
            }
        }

        public void cargarCache()
        {
            try
            {
                using (StreamReader cache = new StreamReader(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\cache.txt"))
                {
                    _cache.Clear();
                    while ((_line = cache.ReadLine()) != null)
                    {
                        _cache.Add(_line.Split(':')[0], _line.Split(':')[1]);
                    }
                    cache.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void escribirCache(bool temporaryFiles)
        {
            StreamWriter Cache = new StreamWriter(
                @"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\cache.txt");
            switch (temporaryFiles)
            {
                case true:
                    Cache.Write("ListFileSize:{0}\nListFileLenght:{1}\nUserName:{2}\nTemporaryFiles:{3}",new System.IO.FileInfo(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\Working\Ex12.2\Listado.txt").Length.ToString(), _listado.Count, Environment.UserName, temporaryFiles);
                    Cache.Close();
                    break;
                case false:
                    Cache.Write("ListFileSize:{0}\nListFileLenght:{1}\nUserName:{2}\nTemporaryFiles:{3}",new System.IO.FileInfo(@"C:\Users\" + Environment.UserName + @"\Documents\Working\Ex12.2\Listado.txt").Length.ToString(), _listado.Count, Environment.UserName, temporaryFiles);
                    Cache.Close();
                    break;
            }
        }

        public void agregarEntradaListado(string nombre, string ruta)
        {
            StreamWriter Listado;
            switch (bool.Parse(_cache["TemporaryFiles"]))
            {
                case true:
                    Listado = new StreamWriter(@"C:\Users\" + _cache["UserName"] + @"\AppData\Local\Temp\Working\Ex12.2\Listado.txt");
                    Listado.WriteLine("{1}:{0}", ruta, nombre);
                    Listado.Close();
                    cargarListadoCache(true);
                    escribirCache(true);
                    cargarCache();
                    break;
                case false:
                    Listado = new StreamWriter( @"C:\Users\" + _cache["UserName"] + @"\Documents\Working\Ex12.2\Listado.txt");
                    Listado.WriteLine("{1}:{0}", ruta, nombre);
                    Listado.Close();
                    cargarListadoCache(false);
                    escribirCache(false);
                    cargarCache();
                    break;
            }
        }

        public void cargarListado(string indentificador) =>
            _employee = _listado[indentificador];

        public void descargarListado(string ruta, string filename)
        {
            WebClient Downloader = new WebClient();
            switch (System.Convert.ToBoolean(_cache["TemporaryFiles"]))
            {
                case true:
                    Downloader.DownloadFileTaskAsync(ruta, @"C:\Users\" + _cache["UserName"] + @"\AppData\Local\Temp\Working\Ex12.2\Lists\"+filename);
                    agregarEntradaListado(filename, @"C:\Users\" + _cache["UserName"] + @"\AppData\Local\Temp\Working\Ex12.2\Lists\"+filename);
                    break;
                case false:
                    Downloader.DownloadFileTaskAsync(ruta, @"C:\Users\" + _cache["UserName"] + @"\Documents\Working\Ex12.2\Lists\"+filename);
                    agregarEntradaListado(filename,@"C:\Users\" + _cache["UserName"] + @"\Documents\Working\Ex12.2\Lists\"+filename);
                    break;
            }
        }

        private void cargarListadoCache(bool TemporaryFiles)
        {
            StreamReader listado;
            switch (TemporaryFiles)
            {
                case true:
                    listado = new StreamReader(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\Working\Ex12.2\Listado.txt");
                    while ((_line = listado.ReadLine()) != null)
                    {
                        _listado.Add(_line.Split('/')[1], _line.Split('/')[0]);
                    }
                    listado.Close();
                    break;
                case false:
                    listado = new StreamReader(@"C:\Users\" + Environment.UserName + @"\Documents\Working\Ex12.2\Listado.txt");
                    while ((_line = listado.ReadLine()) != null)
                    {
                        _listado.Add(_line.Split('/')[1], _line.Split('/')[0]);
                    }
                    listado.Close();
                    break;
            }
        }
        public IDictionary<string, string> Listado() => _listado;
        
        public IDictionary<string, string> Cache() => _cache;

        public string Employee => _employee;
    }
}