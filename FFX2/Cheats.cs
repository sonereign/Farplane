﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farplane.FFX2
{
    public static class Cheats
    {
        public static void GiveAllItems()
        {
            for (int i = 0; i < 68; i++)
            {
                WriteItem(i, i, 99);
            }
        }

        public static void GiveAllAccessories()
        {
            for (int i = 0; i < 128; i++)
            {
                WriteAccessory(i, i, 99);
            }
        }

        public static void WriteItem(int slot, int item, byte count)
        {
            var typeOffset = (int)OffsetType.ItemType + (slot * 2);
            var countOffset = (int)OffsetType.ItemCount + slot;
            if (item == -1) // No item selected
            {
                Memory.WriteBytes(typeOffset, BitConverter.GetBytes((ushort)0xFF));
                Memory.WriteBytes(countOffset, new byte[] { (byte)0 });
            }
            else
            {
                Memory.WriteBytes(typeOffset, BitConverter.GetBytes((ushort)(item + 0x2000)));
                Memory.WriteBytes(countOffset, new byte[] { (byte)count });
            }
        }

        public static void WriteAccessory(int slot, int item, byte count)
        {
            var typeOffset = (int)OffsetType.AccessoryType + (slot * 2);
            var countOffset = (int)OffsetType.AccessoryCount + slot;
            if (item == -1) // No item selected
            {
                Memory.WriteBytes(typeOffset, BitConverter.GetBytes((ushort)0xFF));
                Memory.WriteBytes(countOffset, new byte[] { (byte)0 });
            }
            else
            {
                Memory.WriteBytes(typeOffset, BitConverter.GetBytes((ushort)(item + 0x9000)));
                Memory.WriteBytes(countOffset, new byte[] { (byte)count });
            }
        }

        public static void GiveAllGrids()
        {
            var allGridBytes = new byte[8].Select(gb => gb = (byte) 0xFF).ToArray();
            Memory.WriteBytes((int)OffsetType.KnownGarmentGrids, allGridBytes);
        }
    }
}
