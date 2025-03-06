using System;
using System.Collections.Generic;

namespace WebApi;

public partial class Dump
{
    public Guid UserId { get; set; }

    public string JsonData { get; set; } = null!;

    public byte[] FlatBufferData { get; set; } = null!;
}
