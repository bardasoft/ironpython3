// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information.

#nullable enable

using System;
using System.Collections;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

using Microsoft.Scripting.Runtime;

using IronPython.Runtime;
using IronPython.Runtime.Operations;

using static IronPython.Modules.PythonIOModule;


[assembly: PythonModule("termios", typeof(IronPython.Modules.PythonTermios), PlatformsAttribute.PlatformFamily.Unix)]
namespace IronPython.Modules;

[SupportedOSPlatform("linux")]
[SupportedOSPlatform("macos")]
public static class PythonTermios {

    public const string __doc__ = "Stub of termios, just enough to support module tty.";
    // and also prompt_toolkit.terminal.vt100_input

#pragma warning disable IPY01 // Parameter which is marked not nullable does not have the NotNullAttribute
    [SpecialName]
    public static void PerformModuleReload(PythonContext context, PythonDictionary dict)
        => context.EnsureModuleException("termioserror", dict, "error", "termios");
#pragma warning restore IPY01 // Parameter which is marked not nullable does not have the NotNullAttribute


    #region termios IO Control Codes (TIOC*)

    public static int TIOCGWINSZ => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 0x40087468 : 0x5413;


    #endregion


    #region Other Public Constants
    // Linux: glibc/bits/termios.h (/usr/include/{x86_64,aarch64}-linux-gnu/)
    // macOS: usr/include/sys/termios.h (/Library/Developer/CommandLineTools/SDKs/MacOSX.sdk)

    // iflag
    public const int IGNBRK  = 0x0001;    // ignore break condition
    public const int BRKINT  = 0x0002;    // signal interrupt on break
    public const int IGNPAR  = 0x0004;    // ignore characters with parity errors
    public const int PARMRK  = 0x0008;    // mark parity and framing errors
    public const int INPCK   = 0x0010;    // enable input parity check
    public const int ISTRIP  = 0x0020;    // mask off 8th bit
    public const int INLCR   = 0x0040;    // map NL into CR on input
    public const int IGNCR   = 0x0080;    // ignore CR
    public const int ICRNL   = 0x0100;    // map CR to NL on input
    public static int IXON   => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ?
                               0x0200 : 0x0400;    // enable start output control
    public static int IXOFF  => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ?
                               0x0400 : 0x1000;    // enable stop output control
    public const int IXANY   = 0x0800;    // any char will restart after stop
    public const int IMAXBEL = 0x2000;   // ring bell on input queue full
    public const int IUTF8   = 0x4000;     // maintain state for UTF-8 VERASE


    // oflag
    public const  int OPOST  = 0x0001;    // enable output processing
    public static int ONLCR => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ?
                              0x0002 : 0x0004; // map NL to CR-NL


    // cflag
    public static int CSIZE  => CS5 | CS6 | CS7 | CS8; // number of bits per character
    public static int CS5    =>                                                   0x0000;           // 5 bits per character
    public static int CS6    => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 0x0100 : 0x0010;  // 6 bits per character
    public static int CS7    => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 0x0200 : 0x0020;  // 7 bits per character
    public static int CS8    => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 0x0300 : 0x0030;  // 8 bits per character
    public static int CREAD  => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 0x0800 : 0x0080;  // enable receiver
    public static int PARENB => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 0x1000 : 0x0100;  // parity enable
    public static int HUPCL  => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 0x4000 : 0x0400;  // hang up on last close

    [PythonHidden(PlatformID.MacOSX)]
    public static int CBAUD  => 0x100f;  // mask for baud rate
    [PythonHidden(PlatformID.MacOSX)]
    public static int CBAUDEX => 0x1000;  // extra baud speed mask


    // lflag
    public static uint ECHOKE  => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 0x0001u : 0x0800u;       // visual erase for line kill
    public static uint ECHOE   => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 0x0002u : 0x0010u;       // visually erase chars
    public static uint ECHOK   => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 0x0004u : 0x0020u;       // echo NL after line kill
    public static uint ECHO    =>                                                   0x0008u;                // enable echoing of input characters
    public static uint ECHONL  => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 0x0010u : 0x0040u;       // echo NL even if ECHO is off
    public static uint ECHOPRT => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 0x0020u : 0x0400u;       // visual erase mode for hardcopy
    public static uint ECHOCTL => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 0x0040u : 0x0200u;       // echo control characters as ^(Char)
    public static uint ISIG    => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 0x0080u : 0x0001u;       // enable signals
    public static uint ICANON  => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 0x0100u : 0x0002u;       // canonical mode
    public static uint IEXTEN  => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 0x0400u : 0x8000u;       // enable extended input character processing
    public static uint TOSTOP  => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 0x0040_0000u : 0x0100u;  // stop background jobs from output
    public static uint FLUSHO  => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 0x0080_0000u : 0x1000u;  // output being flushed
    public static uint PENDIN  => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 0x2000_0000u : 0x4000u;  // retype pending input
    public static uint NOFLSH  => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 0x8000_0000u : 0x0080u;  // don't flush after interrupt


    // when the changes take effect:
    public const int TCSANOW   = 0;     // change immediately
    public const int TCSADRAIN = 1;     // flush output, then change
    public const int TCSAFLUSH = 2;     // discard input, flush output, then change


    // control characters
    public static int VEOF     => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ?  0 : 4;
    public static int VEOL     => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ?  1 : 11;
    public static int VEOL2    => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ?  2 : 16;
    public static int VERASE   => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ?  3 : 2;
    public static int VWERASE  => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ?  4 : 14;
    public static int VKILL    => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ?  5 : 3;
    public static int VREPRINT => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ?  6 :  12;
    public static int VINTR    => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ?  8 :  0;
    public static int VQUIT    => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ?  9 :  1;
    public static int VSUSP    => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 10 : 10;
    public static int VSTART   => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 12 :  8;
    public static int VSTOP    => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 13 :  9;
    public static int VLNEXT   => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 14 : 15;
    public static int VDISCARD => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 15 : 13;
    public static int VMIN     => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 16 :  6;
    public static int VTIME    => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 17 :  5;
    [PythonHidden(PlatformID.MacOSX)]
    public static int VSWTC => 7;
    public static int NCCS     => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 20 : 32;


    // tcflush() uses these
    public static int TCIFLUSH  => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 1 : 0;     // flush input
    public static int TCOFLUSH  => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 2 : 1;     // flush output
    public static int TCIOFLUSH => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 3 : 2;     // flush both


    // tcflow() uses these
    public static int TCOOFF => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 1 : 0;     // suspend output
    public static int TCOON  => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 2 : 1;     // restart output
    public static int TCIOFF => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 3 : 2;     // transmit STOP character
    public static int TCION  => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 4 : 3;     // transmit START character

    // baud rates
    public static int B0      => 0;
    public static int B50     => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 50 : 1;
    public static int B75     => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 75 : 2;
    public static int B110    => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 110 : 3;
    public static int B134    => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 134 : 4;
    public static int B150    => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 150 : 5;
    public static int B200    => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 200 : 6;
    public static int B300    => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 300 : 7;
    public static int B600    => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 600 : 8;
    public static int B1200   => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 1200 : 9;
    public static int B1800   => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 1800 : 10;
    public static int B2400   => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 2400 : 11;
    public static int B4800   => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 4800 : 12;
    public static int B9600   => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 9600 : 13;
    public static int B19200  => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 19200 : 14;
    public static int B38400  => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 38400 : 15;
    public static int B57600  => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 57600 : 0x1001;
    public static int B115200 => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 115200 : 0x1002;
    public static int B230400 => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 230400 : 0x1003;
    // higher baud rates are not defined on macOS

    public static object tcgetattr(CodeContext context, int fd) {
        if (fd < 0) throw PythonOps.ValueError("file descriptor cannot be a negative integer ({0})", fd);
        if (fd > 0) throw new NotImplementedException("termios support only for stdin");

        if (context.LanguageContext.SystemStandardIn is not TextIOWrapper stdin) {
            throw new NotImplementedException("termios support only for stdin");
        }
        if (stdin.closed || !stdin.isatty(context) || stdin.fileno(context) != 0 || Console.IsInputRedirected) {
            throw new NotImplementedException("termios support only for stdin connected to tty");
        }

        var cc = new PythonList(NCCS);
        var specialChars = RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? macos__specialChars : linux__specialChars;
        for (int i = 0; i < NCCS; i++) {
            byte c = i < specialChars.Length ? specialChars[i] : (byte)0;
            cc.Add(Bytes.FromByte(c));
        }
        return PythonList.FromArrayNoCopy([
            _iflag,
            _oflag,
            _cflag,
            _lflag,
            _ispeed,
            _ospeed,
            cc
        ]);
    }

    public static object tcgetattr(CodeContext context, object? file) {
        if (!ReferenceEquals(file, context.LanguageContext.SystemStandardIn)) {
            throw new NotImplementedException("termios support only for stdin");
        }
        return tcgetattr(context, 0);
    }


    public static void tcsetattr(CodeContext context, int fd, int when, object? attributes) {
        if (fd != 0) throw new NotImplementedException();

        if (context.LanguageContext.SystemStandardIn is not TextIOWrapper stdin) {
            throw new NotImplementedException("termios support only for stdin");
        }
        if (stdin.closed || !stdin.isatty(context) || stdin.fileno(context) != 0 || Console.IsInputRedirected) {
            throw new NotImplementedException("termios support only for stdin connected to tty");
        }

        if (attributes is not IList attrs || attrs.Count != 7) {
            throw PythonOps.TypeError("tcsetattr, arg 3: must be 7 element list");
        }

        uint newLflag = attrs[LFlagIdx] switch {
            int i => (uint)i,
            uint ui => ui,
            long l => (uint)l,
            BigInteger bi => (uint)bi,
            Extensible<BigInteger> ebi => (uint)ebi.Value,
            _ => throw PythonOps.TypeErrorForBadInstance("tcsetattr: an integer is required (got type {0})", attrs[LFlagIdx])
        };

        if (attrs[SpecialCharsIdx] is not IList chars || chars.Count != NCCS) {
            throw PythonOps.TypeError("tcsetattr, atributes[{0}] must be {1} element list", SpecialCharsIdx, NCCS);
        }

        var specialChars = RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? macos__specialChars : linux__specialChars;
        for (int i = 0; i < chars.Count; i++) {
            object? o = chars[i];
            int newVal;
            if (o is Bytes b && b.Count == 1) {
                newVal = b[0];
            } else if (!Converter.TryConvertToInt32(o, out newVal)) {
                throw PythonOps.TypeError("tcsetattr: elements of attributes must be characters or integers");
            }
            int expected = i < specialChars.Length ? specialChars[i] : 0;
            if (newVal != expected) {
                throw new NotImplementedException("tcsetattr: setting special characters is not supported");
            }
        }

        if (when != TCSANOW) {
            stdin.flush(context);
        }

        if ((newLflag & (ECHO | ICANON | IEXTEN | ISIG)) == 0) {
            setraw(context, stdin);
        } else {
            setcbreak(context, stdin);
        }
    }


    public static void tcsetattr(CodeContext context, object? file, int when, [NotNone] object attributes) {
        if (!ReferenceEquals(file, context.LanguageContext.SystemStandardIn)) {
            throw new NotImplementedException("termios support only for stdin");
        }
        tcsetattr(context, 0, when, attributes);
    }

    #endregion


    private const int IFlagIdx = 0;
    private const int OFlagIdx = 1;
    private const int CFlagIdx = 2;
    private const int LFlagIdx = 3;
    private const int ISpeedIdx = 4;
    private const int OSpeedIdx = 5;
    private const int SpecialCharsIdx = 6;

    private static int _iflag  => BRKINT | ICRNL | IXON | IXANY | IMAXBEL | IUTF8;
    private static int _oflag  => OPOST | ONLCR;
    private static int _cflag  => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ?
                                    CS8 | CREAD | HUPCL
                                  : CS8 | CREAD | HUPCL | (CBAUD & ~CBAUDEX);
    private static uint _lflag => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ?
                                    ECHOKE | ECHOE | ECHOK | ECHO | ECHOCTL | ISIG | ICANON | IEXTEN | PENDIN
                                  : ECHOKE | ECHOE | ECHOK | ECHO | ECHOCTL | ISIG | ICANON | IEXTEN;
    private static int _ispeed => B38400;
    private static int _ospeed => B38400;

    private static readonly byte[] macos__specialChars = [
        (byte)0x04, // VEOF     ^D
        (byte)0xff, // VEOL
        (byte)0xff, // VEOL2
        (byte)0x7f, // VERASE   DEL
        (byte)0x17, // VWERASE  ^W
        (byte)0x15, // VKILL    ^U
        (byte)0x12, // VREPRINT ^R
        (byte)0x00, // reserved
        (byte)0x03, // VINTR    ^C
        (byte)0x1c, // VQUIT    ^\
        (byte)0x1a, // VSUSP    ^Z
        (byte)0x19, // VDSUSP   ^Y
        (byte)0x11, // VSTART   ^Q
        (byte)0x13, // VSTOP    ^S
        (byte)0x16, // VLNEXT   ^V
        (byte)0x0f, // VDISCARD ^O
        (byte)0x01, // VMIN
        (byte)0x00, // VTIME
        (byte)0x14, // VSTATUS  ^T
        (byte)0x00, // reserved
    ];

    private static readonly byte[] linux__specialChars = [
        (byte)0x03, // VINTR    ^C
        (byte)0x1c, // VQUIT    ^\
        (byte)0x7f, // VERASE   DEL
        (byte)0x15, // VKILL    ^U
        (byte)0x04, // VEOF     ^D
        (byte)0x00, // VTIME
        (byte)0x01, // VMIN
        (byte)0x00, // VSWTC
        (byte)0x11, // VSTART   ^Q
        (byte)0x13, // VSTOP    ^S
        (byte)0x1a, // VSUSP    ^Z
        (byte)0xff, // VEOL
        (byte)0x12, // VREPRINT ^R
        (byte)0x0f, // VDISCARD ^O
        (byte)0x17, // VWERASE  ^W
        (byte)0x16, // VLNEXT   ^V
        (byte)0xff, // VEOL2
        // rest are reserved
    ];


    private static object? _savedRawStdin;

    private static void setraw(CodeContext context, TextIOWrapper stdin) {
        if (_savedRawStdin is null && stdin.buffer is BufferedReader reader) {
            _savedRawStdin = reader.raw;
            reader.raw = new RawConsole(context);
        }
    }

    private static void setcbreak(CodeContext context, TextIOWrapper stdin) {
        if (_savedRawStdin is not null 
            && stdin.buffer is BufferedReader reader
            && reader.raw is RawConsole) {

            reader.raw = _savedRawStdin;
            _savedRawStdin = null;
        }
    }

    private class RawConsole : _RawIOBase {
        public RawConsole(CodeContext context) : base(context) {
        }

        public override object? read(CodeContext context, object? size=null) {
            int intSize = size switch {
                null => -1,
                int i => i,
                BigInteger bi => (int)bi,
                Extensible<BigInteger> ebi => (int)ebi.Value,
                _ => throw PythonOps.TypeErrorForBadInstance("integer argument expected, got '{0}'", size)
            };
            if (intSize == 0) return null;

            ConsoleKeyInfo info = Console.ReadKey(intercept: true);
            return Bytes.FromByte(unchecked((byte)info.KeyChar));
        }

        public override int fileno(CodeContext context) => 0;
        public override bool isatty(CodeContext context) => true;
    }

    private static int ToInt(this object? o)
        => o switch {
            int i => i,
            BigInteger bi => (int)bi,
            Extensible<BigInteger> ebi => (int)ebi.Value,
            _ => throw PythonOps.TypeErrorForBadInstance("an integer is required (got type {0})", o)
        };
}
