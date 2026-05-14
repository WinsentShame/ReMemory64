using ReMemory64;

namespace Rekit
{
    public class LocalPlayer : MemoryStruct
    {
        private static readonly int lpBaseAddress = 0x01921DF8;
        private static readonly int[] lpBaseOffsets = { 0x30, 0x30, 0x0, 0x58, 0x18, 0x0, 0x0 };
        public LocalPlayer(BaseMemory memory)
            : base(memory, lpBaseAddress, lpBaseOffsets) { }
        public enum Offsets : int
        {
            /// <summary>
            /// float
            /// </summary>
            positionIsNominalX = 0x88,

            /// <summary>
            /// float
            /// </summary>
            positionIsNominalY = 0x8C,

            /// <summary>
            /// float
            /// </summary>
            positionIsNominalZ = 0x90,

            /// <summary>
            /// float
            /// </summary>
            positionIsX = 0x160,

            /// <summary>
            /// float
            /// </summary>
            positionIsY = 0x164,

            /// <summary>
            /// float
            /// </summary>
            positionIsZ = 0x168,

            /// <summary>
            /// float
            /// -1.401298464E-45
            /// </summary>
            velocityIsX = 0xAC,

            /// <summary>
            /// float
            /// -0.07840000093
            /// </summary>
            velocityIsY = 0xB0,

            /// <summary>
            /// float
            /// 1.401298464E-45
            /// </summary>
            velocityIsZ = 0xB4,

            /// <summary>
            /// float
            /// </summary>
            rotationYaw = 0xBC,

            /// <summary>
            /// float
            /// </summary>
            rotationPitch = 0xB8,

            /// <summary>
            /// float
            /// </summary>
            rotationNominalYaw = 0xC0,

            /// <summary>
            /// float
            /// </summary>
            rotationNHominalPitch = 0xC4,

            /// <summary>
            /// 4 bytes
            /// 16842752
            /// </summary>
            airMovement = 0x12C,

            /// <summary>
            /// 4 bytes
            /// 65792
            /// </summary>
            isAir = 0x130,

            /// <summary>
            /// float
            /// 0
            /// </summary>
            isFalling = 0x134,

            /// <summary>
            /// 4 bytes
            /// 2 - Exploding dynamite (Do not use on yourself!)
            /// 5 - Chicken
            /// 6 - Cow
            /// 7 - Mushroom cow
            /// 8 - Pig
            /// 9 - Sheep
            /// 10 - Bat
            /// 11 - Wolf
            /// 12 - Ender dragon (Strange behavior)
            /// 13 - Polar bear
            /// 14 - Village
            /// 16 - Zombie
            /// 17 - Zombie pig
            /// 19 - Ghast
            /// 20 - Blaze
            /// 21 - Skeleton
            /// 23 - Silverfish
            /// 24 - Creeper
            /// 26 - Enderman
            /// 27 - Arrow (Do not use on yourself!)
            /// 28 - Shulker bullet (Do not use on yourself!)
            /// 29 - Bobber (Do not use on yourself!)
            /// 30 - Player
            /// 31 - Egg (Do not use on yourself!)
            /// 32 - Snowball (Do not use on yourself!)
            /// 33 - Ender pearls (Do not use on yourself!)
            /// 34 - Vial (Do not use on yourself!)
            /// 35 - Scattering bubble (Do not use on yourself!)
            /// 39 - Boat (Do not use on yourself!)
            /// 40 - Octopus (:D)
            /// 41 - Fireball (Do not use on yourself!)
            /// 42 - Mini fireball (Do not use on yourself!)
            /// 43 - Dragon fireball
            /// 44 - Idk.. (Do not use on yourself!)
            /// 45 - Zombie village
            /// 46 - Exp (Do not use on yourself!)
            /// 47 - Lightning (Do not use on yourself!)
            /// 48 - Iron golem (Mac)
            /// 49 - Ocelot
            /// 50 - Snowman
            /// 51 - Shulker
            /// 52 - Exp bottle (Do not use on yourself!)
            /// 53 - Rabbit
            /// 54 - Witch
            /// 56 - Llama
            /// 57 - Cameraman
            /// 62 - Ancient Guardian
            /// 63 - Unknown Wanderer
            /// 65 - Wither
            /// 66 - Wither shell
            /// 68 - Desert Zombie
            /// 69 - Stray
            /// 70 - Skeleton
            /// 71 - Eye of ender (Do not use on yourself!)
            /// 72 - Ender crystal (Do not use on yourself!)
            /// 73 - Endermite
            /// 74 - Evoker
            /// 76 - Vex
            /// 77 - Vindicator
            /// </summary>
            entityId = 0x14C,

            /// <summary>
            /// double
            /// 0.0000976562732830644
            /// </summary>
            hitboxWidth = 0x194,

            /// <summary>
            /// float
            /// 1.799999952
            /// </summary>
            hitboxHeight = 0x19C,

            /// <summary>
            /// double
            /// 0.00006103515625
            /// </summary>
            stepSize = 0x1A8,

            /// <summary>
            /// 4 bytes
            /// 0
            /// </summary>
            burnDurtaion = 0x1EC,

            /// <summary>
            /// 4 bytes
            /// 0 && 1
            /// </summary>
            isBurn = 0x1F0,

            /// <summary>
            /// 4 bytes
            /// 0
            /// </summary>
            eatMoment = 0x14C0,

            /// <summary>
            /// float
            /// 0.01999999955
            /// </summary>
            airSpeed = 0x10F0,

            /// <summary>
            /// 4 bytes
            /// 0 && 1
            /// </summary>
            isHit = 0x10DC,

            /// <summary>
            /// 4 bytes
            /// 0 
            /// </summary>
            duritonHit = 0x10E0,

            /// <summary>
            /// 4 bytes
            /// 0 && 1
            /// </summary>
            isJump = 0x1130,

            /// <summary>
            /// 4 bytes
            /// 0
            /// </summary>
            durationJump = 0x1134,

            /// <summary>
            /// 4 bytes
            /// move left = 0x1065353216
            /// move left to foward = 0x1060439283
            /// move left to back = 0x1060439283
            /// 
            /// move right = 0x3212836864
            /// move right to foward = 0x3207922931
            /// move right to back = 0x1060439283
            /// </summary>
            relativelyMove = 0x1190,

            /// <summary>
            /// 4 bytes
            /// move foward = 0x1065353216
            /// move foward to left = 0x1060439283
            /// move foward to right = 0x1065353216
            /// 
            /// move back = 0x3212836864
            /// move back to left = 0x3207922931
            /// move back to right = 0x3207922931
            /// </summary>
            saggitalMove = 0x1194,

            /// <summary>
            /// 4 bytes
            /// 0 && 1
            /// </summary>
            isMove = 0x119C,

            /// <summary>
            /// float
            /// 0.1000000015
            /// </summary>
            groundSpeed = 0x1140,

            /// <summary>
            /// 4 bytes
            /// 0
            /// </summary>
            durtaionHandAnimation = 0x11FC,

            /// <summary>
            /// Double
            /// 0.0078125
            /// </summary>
            fovEffect = 0x14DC,

            /// <summary>
            /// string
            /// </summary>
            nickName = 0x1258,

            /// <summary>
            /// 4 bytes
            /// 64
            /// </summary>
            loadedChunk = 0x1574,

            /// <summary>
            /// 4 bytes
            /// there are too many of them <|
            /// </summary>
            animationPlayerList = 0x15A4,

            /// <summary>
            /// 4 bytes
            /// </summary>
            currentSlot = 0x16B8,
        }
    }
}
