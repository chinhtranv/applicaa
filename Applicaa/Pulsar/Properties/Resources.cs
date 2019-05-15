// Decompiled with JetBrains decompiler
// Type: SIMS.UserInterfaces.Properties.Resources
// Assembly: Pulsar, Version=7.180.40.0, Culture=neutral, PublicKeyToken=21f532fe36bf9cd6
// MVID: 426271C6-CBAA-459D-A1E4-8EB841AEB1DD
// Assembly location: C:\Program Files (x86)\SIMS\SIMS .net\Pulsar.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace SIMS.UserInterfaces.Properties
{
  [DebuggerNonUserCode]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) SIMS.UserInterfaces.Properties.Resources.resourceMan, (object) null))
          SIMS.UserInterfaces.Properties.Resources.resourceMan = new ResourceManager("SIMS.UserInterfaces.Properties.Resources", typeof (SIMS.UserInterfaces.Properties.Resources).Assembly);
        return SIMS.UserInterfaces.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return SIMS.UserInterfaces.Properties.Resources.resourceCulture;
      }
      set
      {
        SIMS.UserInterfaces.Properties.Resources.resourceCulture = value;
      }
    }
  }
}
