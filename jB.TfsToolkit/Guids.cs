// Guids.cs
// MUST match guids.h

using System;

namespace Joerg.Battermann.TfsToolkit
{
    static class GuidList
    {
        public const string guidTfsToolkitPkgString = "becd428b-780f-4008-87f3-070d1dbe1038";
        public const string guidTfsToolkitCmdSetString = "a6ce3d8f-b2ac-4131-98a8-b091f8871c92";

        public static readonly Guid guidTfsToolkitCmdSet = new Guid(guidTfsToolkitCmdSetString);
    };
}