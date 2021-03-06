﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACE.Network
{
    public class ClientPacketFragment : PacketFragment
    {
        public BinaryReader Payload { get; }
        public MemoryStream Data { get; private set; }

        public ClientPacketFragment(BinaryReader payload)
        {
            Header = new PacketFragmentHeader(payload);
            Data = new MemoryStream(payload.ReadBytes((int)(Header.Size - PacketFragmentHeader.HeaderSize)));
            Payload = new BinaryReader(Data);
        }
    }
}
