
using KTPO4311.Yablonskas.Lib.src.Common;
using KTPO4311.Yablonskas.Lib.src.LogAn;
using KTPO4311.Yablonskas.Lib.src.SampleCommands;
using KTPO4311.Yablonskas.Service.src.WindsorInstallers;

//LogAnalyzer loger = new();

//string rightfile = "rightfile.ext";
//string falsefile = "falsefile.exp";

//Console.WriteLine("Checking Right extension of "+ rightfile +": " +  loger.IsValidLogFileName(rightfile));
//Console.WriteLine("Checking Right extension of " + falsefile + ": " + loger.IsValidLogFileName(falsefile));


CastleFactory.container.Install(
    new SampleCommandInstaller(), new ViewInstaller());


for (int i = 0; i < 3; i++)
{
    ISampleCommand someCommand = CastleFactory.container.Resolve<ISampleCommand>();
    someCommand.Execute();
}