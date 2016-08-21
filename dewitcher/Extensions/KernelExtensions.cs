/*
Copyright (c) 2012-2013, dewitcher Team
All rights reserved.

Redistribution and use in source and binary forms, with or without modification,
are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice
   this list of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright notice,
  this list of conditions and the following disclaimer in the documentation
  and/or other materials provided with the distribution.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR
IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER
IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF
THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using dewitcher2.Core;
using dewitcher;

namespace dewitcher2
{
    /// <summary>
    /// Useful kernel extensions
    /// </summary>
    public static class KernelExtensions
    {
        public static void Reboot(this Cosmos.System.Kernel krnl) { ACPI.Reboot(); }
        public static void Shutdown(this Cosmos.System.Kernel krnl) { ACPI.Shutdown(); }
        public static void SleepSeconds(this Cosmos.System.Kernel krnl, uint value) { dewitcher.Core.PIT.SleepSeconds(value); }
        public static void SleepMilliseconds(this Cosmos.System.Kernel krnl, uint value) { dewitcher.Core.PIT.SleepMilliseconds(value); }
        public static uint GetMemory(this Cosmos.System.Kernel krnl) { return GetRAM.GetAmountOfRAM + 1; }
        public static void ShowBootscreen(this Cosmos.System.Kernel krnl, string OSname, Bootscreen.Effect efx,
            ConsoleColor color, int ticks = 10000000) { Bootscreen.Show(OSname, efx, color, ticks); }
        public static void AllocMemory(this Cosmos.System.Kernel krnl, uint aLength) { Heap.MemAlloc(aLength); }
    }
}
