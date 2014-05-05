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

        public static void setXlive(bool set)                  //Kill xlive (true = xlive enabled, false = disabled)
        {
            int address = 0xF1605;                      //xlive.dll + 0xf1605 is the address of the start of the function we want to jump
            byte killbyte = 0xeb;
            byte restorebyte = 0x74;        
                if (set)
                {
                    Memory.Write(Memory.BaseAddress("xlive.dll") + address, restorebyte);
                }
                else
                {
                    Memory.Write(Memory.BaseAddress("xlive.dll") + address, killbyte);
                }          
        }

        public static bool paused = false;
        public static void PauseGame(bool pause)        //NOP's the pause function and sets the pause state to 1 if true, opposite if false. Leads to crashes!
        {
            int ipause = 0;
           // byte[] original = new byte[6] { 0x09, 0x81, 0x24, 0x13, 0x00, 0x00 }; //the original function
            byte[] original1 = new byte[6] { 0x21, 0x81, 0x24, 0x13, 0x00, 0x00 }; //the original function
           // int pauseFuncAddress = 0x005CCD56; //0x005CCD68
            int pauseFuncAddress1 = 0x005CCD68; //Original
            

            if (pause)              //if paused, nop the func
            {
                ipause = 1;
                //     setXlive(false); //Disable xlive //UNCOMMENT THIS TO MAKE IT WORK AFTER USER HAS PRESSED PAUSE. MAKES THE GAME CRASH MORE OFTEN
                paused = true;
             //   NOP(pauseFuncAddress + steamoffset, 6);
                //      NOP(pauseFuncAddress1 + steamoffset, 6); //UNCOMMENT THIS TO MAKE IT WORK AFTER USER HAS PRESSED PAUSE. MAKES THE GAME CRASH MORE OFTEN
            }
            else                    //else restore it
            {
                //     setXlive(true); // reenable xlive //UNCOMMENT THIS TO MAKE IT WORK AFTER USER HAS PRESSED PAUSE. MAKES THE GAME CRASH MORE OFTEN
                paused = false;
              //  writeBytes(pauseFuncAddress + steamoffset, original);
          //      writeBytes(pauseFuncAddress1 + steamoffset, original1);    //UNCOMMENT THIS TO MAKE IT WORK AFTER USER HAS PRESSED PAUSE. MAKES THE GAME CRASH MORE OFTEN
            }
            
            Memory.Write(Memory.BaseAddress() + 0x810394 + steamoffset, ipause); //Set the new pause state
        }

        public static void setPauseState(int ipause)  //Only works if the pausefunc is already NOP'd
        {
            Memory.Write(Memory.BaseAddress() + 0x810394 + steamoffset, ipause);
        }


        public static void NOP(int address, int bytes)
        {
            byte NOPbyte = 0x90;
            /*                                          //this is done elsewhere for this particular function
            if (Properties.Settings.Default.Steam)
            {
                address += 0x10c0;
            }
            */
        
                for (int i = 0; i < bytes; i++)
                {
                    Memory.Write(address + i, NOPbyte);
                }        
        }

        public static void writeBytes(int startaddress, byte[] bytes)
        {/*                                         //this is done elsewhere for this particular function
            if (Properties.Settings.Default.Steam)
            {
                startaddress += 0x10c0;
            }*/

          
                for (int i = 0; i < bytes.Length; i++)
                {
                    Memory.Write(startaddress + i, bytes[i]);
                }           
        }

        public static void WaitFrames(int framesToWait)               //Waits specified amount of frames.
        {
            int frames;
            int address = 0x80f0d0 + steamoffset;
     
                frames = Convert.ToInt32(Memory.ReadInt(Memory.BaseAddress() + address, new int[] { 0x1c4 }));
                int finalFrame = frames + framesToWait;
             
                while (frames < finalFrame)
                {
                    frames = Convert.ToInt32(Memory.ReadInt(Memory.BaseAddress() + address, new int[] { 0x1c4 }));
                }
        }

   
    }
}
