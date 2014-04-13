using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoryEditor;

namespace SF4BoxViewerDX
{
    class readMemory
    {
        public static Memory Memory = new Memory();

        public static bool openProcess()
        {
            if (Memory.OpenProcess("SSFIV"))
            {
                return true;
            }
            else
            {
                return false;
            } 
        }
        

        public static byte[] readMemoryAOB(int address, int[] offsets, uint bytestoread)
        {
                byte[] readmemory;
                readmemory = Memory.ReadAOB(Memory.BaseAddress() + address, offsets, bytestoread);
                return readmemory;
        }
        public static byte[] readMemoryAOBStatic(int address, uint bytestoread)
        {
            byte[] readmemory;

                readmemory = Memory.ReadAOB(address, bytestoread);
                return readmemory;
        }

        public static int readMemoryInt(int address, int[] offsets)
        {

            int readmem = -1;

                readmem = Convert.ToInt32(Memory.ReadInt(Memory.BaseAddress() + address, offsets));
          
            return readmem;
        }

        public static float readMemoryFloatNoOffsets(int address)
        {
      
            float readmem = -1;

                readmem = Memory.ReadFloat(Memory.BaseAddress() + address);
            
            return readmem;
        }

        public static int readMemoryIntNoOffsets(int address)
        {

            int readmem = -1;
      
                readmem = Convert.ToInt32(Memory.ReadInt(Memory.BaseAddress() + address));
            
            return readmem;
        }

        public static float readMemoryFloat(int address, int[] offsets)
        {
         
            float readmem = -1;
       
                readmem = Memory.ReadFloat(Memory.BaseAddress() + address, offsets);
            
            return readmem;
        }

        public static int readMemoryIntStatic(int address)
        {
      
            int readmem = -1;
         
                readmem = Convert.ToInt32(Memory.ReadInt(address));
            
            return readmem;
        }

        public static float readMemoryFloatStatic(int address)
        {
          
            float readmem = -1;
    
                readmem = Memory.ReadFloat(address);
            
            return readmem;
        }

        public static int steamoffset = 0x0;

        public static float GetCamX()
        {
            int address = 0x0080F0DC + steamoffset;

            float CamX = 0;
   
                CamX = Memory.ReadFloat(Memory.BaseAddress() + address, new int[] { 0x130, 0x90 });
            

            return CamX;
        }


        public static float GetCamY()
        {
            int address = 0x0080F0DC + steamoffset;
            float CamY = 0;
    
                CamY = Memory.ReadFloat(Memory.BaseAddress() + address, new int[] { 0x130, 0x94 });
            

            return CamY;
        }

        public static float GetCamZ()
        {
            int address = 0x0080F0DC + steamoffset;
   
            float CamZ = 0;
          
                CamZ = Memory.ReadFloat(Memory.BaseAddress() + address, new int[] { 0x130, 0x98 });
            

            return CamZ;
        }

        public static float GetCamXp()
        {
            int address = 0x0080F0DC + steamoffset;
         
            float CamX = 0;
        
                CamX = Memory.ReadFloat(Memory.BaseAddress() + address, new int[] { 0x130, 0xA0 });
            

            return CamX;
        }

        public static float GetCamYp()
        {
            int address = 0x0080F0DC + steamoffset;
           
            float CamY = 0;
           
                CamY = Memory.ReadFloat(Memory.BaseAddress() + address, new int[] { 0x130, 0xA4 });
            

            return CamY;
        }

        public static float GetCamZp()
        {
            int address = 0x0080F0DC + steamoffset;
            
            float CamY = 0;
           
            
                CamY = Memory.ReadFloat(Memory.BaseAddress() + address, new int[] { 0x130, 0xA8 });
            

            return CamY;
        }

        public static float GetCamZoom()
        {
            int address = 0x0080F0DC + steamoffset;
           
            float zoom = 0;

       
                zoom = Memory.ReadFloat(Memory.BaseAddress() + address, new int[] { 0x130, 0xD8 });
            

            return zoom;
        }

    }
}
