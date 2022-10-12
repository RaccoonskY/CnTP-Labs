
using KTPO4311.Yablonskas.Lib.src.LogAn;

LogAnalyzer loger = new();

string rightfile = "rightfile.ext";
string falsefile = "falsefile.exp";

Console.WriteLine("Checking Right extension of "+ rightfile +": " +  loger.IsValidLogFileName(rightfile));
Console.WriteLine("Checking Right extension of " + falsefile + ": " + loger.IsValidLogFileName(falsefile));