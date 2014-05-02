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


        //Under are for gathering info to show on screen.

        public static int getP2Health()
        {
            int address = 0x0080F0CC + steamoffset;
            int p2Health = 0;
            p2Health = Convert.ToInt32(Memory.ReadInt(Memory.BaseAddress() + address, new int[] { 0xc, 0x6c5c }));
            return p2Health / 65536;                    //divide by 65536 to get the real health

        }

        public static int getP1Health()
        {
            int address = 0x0080F0CC + steamoffset;
            int p1Health = 0;
            p1Health = Convert.ToInt32(Memory.ReadInt(Memory.BaseAddress() + address, new int[] { 0x8, 0x6c5c }));
            return p1Health / 65536;                    //divide by 65536 to get the real health
        }

        public static float getP1PosX()                            //get p1 x-position
        {
            int address = 0x0080F0CC + steamoffset;    
            float p1PosX = 0;
            p1PosX = Memory.ReadFloat(Memory.BaseAddress() + address, new int[] { 0x8, 0x60 });            
            return p1PosX;
        }


        public static float getP1PosY()                            //get p1 y-position
        {
            int address = 0x0080F0CC + steamoffset;      
            float p1PosY = 0;
            p1PosY = Memory.ReadFloat(Memory.BaseAddress() + address, new int[] { 0x8, 0x64 });           
            return p1PosY;
        }

        public static float getP2PosX()                            //Get p2 x-position
        {
            int address = 0x0080F0CC + steamoffset;       
            float p2PosX = 0;
            p2PosX = Memory.ReadFloat(Memory.BaseAddress() + address, new int[] { 0xC, 0x60 });           
            return p2PosX;
        }

        public static float getP2PosY()                            //get p2 y-position
        {
            int address = 0x0080F0CC + steamoffset;         
            float p2PosY = 0;
            p2PosY = Memory.ReadFloat(Memory.BaseAddress() + address, new int[] { 0xC, 0x64 });          
            return p2PosY;
        }

        public static float getDistance()                          //Get the distance between the two characters (x-distance)
        {
            float P1PosX = getP1PosX();
            float P2PosX = getP2PosX();
            float distance = 0;

            if (P1PosX > P2PosX)
            {
                distance = P1PosX - P2PosX;
            }
            else
            {
                distance = P2PosX - P1PosX;
            }

            return distance;
        }

        public static int getP1EXmeter()
        {
            int address = 0x0080F0CC + steamoffset;      
            int EXmeter = 0;
            EXmeter = Convert.ToInt32(Memory.ReadInt(Memory.BaseAddress() + address, new int[] { 0x8, 0x6C64 }));            
            EXmeter = EXmeter / 655360;             //convert to percent (65536000 is 100%)
            return EXmeter;
        }

        public static int getP2EXmeter()
        {
            int address = 0x0080F0CC + steamoffset;
            int EXmeter = 0;
            EXmeter = Convert.ToInt32(Memory.ReadInt(Memory.BaseAddress() + address, new int[] { 0xC, 0x6C64 }));
            EXmeter = EXmeter / 655360;             //convert to percent (65536000 is 100%)
            return EXmeter;
        }

        public static int getP1UltraMeter()
        {
            int address = 0x0080F0CC + steamoffset;
            int Umeter = 0;
            Umeter = Convert.ToInt32(Memory.ReadInt(Memory.BaseAddress() + address, new int[] { 0x8, 0x6C78 }));           
            Umeter = Umeter / 262144;             //convert to percent (26214400 is 100%)
            return Umeter;
        }

        public static int getP2UltraMeter()
        {
            int address = 0x0080F0CC + steamoffset;
            int Umeter = 0;
            Umeter = Convert.ToInt32(Memory.ReadInt(Memory.BaseAddress() + address, new int[] { 0xC, 0x6C78 }));
            Umeter = Umeter / 262144;             //convert to percent (26214400 is 100%)
            return Umeter;
        }

        public static int ComboCounter()                  //There is only one combo counter. It's the same for both players
        {
            int address = 0x0080F0D0 + steamoffset;
            int counter = 0;
            counter = Convert.ToInt32(Memory.ReadInt(Memory.BaseAddress() + address, new int[] { 0x130 }));           
            return counter;
        }

        public static int getStun(int player)                            //get stun
        {
            int address = 0x0080F0CC + steamoffset;       
            int stun = 0;
        
                if (player == 1)
                {
                    stun = Convert.ToInt32(Memory.ReadInt(Memory.BaseAddress() + address, new int[] { 0x8, 0x6c8c }));
                }
                else if (player == 2)
                {
                    stun = Convert.ToInt32(Memory.ReadInt(Memory.BaseAddress() + address, new int[] { 0xc, 0x6c8c }));
                }            
            return stun / 65536;
        }

        public static int playerAnim(int player) //Returns animation number
        {
            int address = 0x0080F0CC + steamoffset;
            int action = -1;
                if (player == 1)
                    action = readMemoryInt(address, new int[] { 0x8, 0xA0, 0x14 });
                else
                    action = readMemoryInt(address, new int[] { 0xc, 0xA0, 0x14 });
            return action;
        }

        public static int getAnimFrameP1() //Returns which frame the animation is on
        {
            byte[] anim = readMemoryAOB(0x0080F0CC + steamoffset, new int[] { 0x8, 0xA0, 0x1A }, 2);
            return System.BitConverter.ToInt16(anim, 0);
        }

        public static int getAnimFrameP2()
        {
            byte[] anim = readMemoryAOB(0x0080F0CC + steamoffset, new int[] { 0xC, 0xA0, 0x1A }, 2);
            return System.BitConverter.ToInt16(anim, 0);         
        }

    }
}
