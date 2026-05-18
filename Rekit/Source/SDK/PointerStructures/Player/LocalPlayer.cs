using ReMemory64;

namespace Rekit
{
    public class LocalPlayer : PointerStruct
    {
        public LocalPlayer(BaseMemory memory)
            : base(memory, 0x01921DF8, new int[] { 0x30, 0x30, 0x0, 0x58, 0x18, 0x0, 0x0 }) { }

        private enum Offsets : int
        {
            visibleModel = 0x50,
            positionNominalX = 0x88,
            positionNominalY = 0x8C,
            positionNominalZ = 0x90,
            positionNominalX2 = 0x94,
            positionNominalY2 = 0x98,
            positionNominalZ2 = 0x9C,
            positionNominalX3 = 0xA0,
            positionNominalY3 = 0xA4,
            positionNominalZ3 = 0xA8,
            velocityX = 0xAC,
            velocityY = 0xB0,
            velocityZ = 0xB4,
            rotationYaw = 0xB4,
            rotationPitch = 0xBC,
            rotationNominalYaw = 0xC0,
            rotationNominalPitch = 0xC4,
            positionNominalX4 = 0xE0,
            positionNominalY4 = 0xE4,
            positionNominalZ4 = 0xE8,
            oneCameraPreset = 0xEC,
            airMove = 0x12C,
            airJump = 0x130,
            isFalling = 0x134,
            entityId = 0x14C,
            oneCameraPositionZ = 0x16A,
            oneCameraPoisitionXZ = 0x16B,
            positionX = 0x16C,
            positionY = 0x170,
            positionZ = 0x174,
            hitboxWidth = 0x194,
            hitboxHeight = 0x19C,
            sightPositionHeight = 0x1A0,
            stepSize = 0x1A8,
            oneCameraShakeIndicatorX = 0x1B4,
            oneCameraShakeIndicatorZ = 0x1B8,
            oneCameraItemShake = 0x18BC,
            oneCameraBurn = 0x1E4,
            oneCameraBurnDuration = 0x1E8,
            fireModel = 0xE6C,
            hurtCameraDuration = 0xE70,
            killModel = 0xE7C,
            jumpCameraDuration = 0xE88,
            animationLegMove1 = 0xEA0,
            animationLegMove2 = 0xEA4,
            animationLegDuration = 0x10D4,
            isHit = 0x10DC,
            isHitDuration = 0x10E0,
            airSpeed1 = 0x10E8,
            airSpeed2 = 0x10F0,
            relativelyMove = 0x1190,
            saggitalMove = 0x1194,
            isNickName = 0x1258,
            isMove = 0x119C,
            isUse = 0x1470,
            isEat = 0x14C0,
            isJump = 0x1130,
            isJumpDuration = 0x1134,
            fieldOfView = 0x14DC,     
            loadedSourceChunk = 0x1574,
            playerModelStyle = 0x15A4,
            netherPortalCameraEffect = 0x15E0,
            usJumpDurationActivity = 0x1658,
            countCurrentItem = 0x1668,
            currentSlot = 0x16B8
        }
        // Instance Structures
        public Item GetCurrentItem() => ReadPointerStruct<Item>(0x1678);
        public Item GetMultiPlayerLevel() => ReadPointerStruct<Item>(0x58);
        public Item GetEntityDefintionGroup() => ReadPointerStruct<Item>(0x60);
        public Item GetBlockSource() => ReadPointerStruct<Item>(0xD8);
        public Item GetLookControl() => ReadPointerStruct<Item>(0x1148);
        public Item GetBodyControl() => ReadPointerStruct<Item>(0x150);
        public Item GetPlayrChunkSource() => ReadPointerStruct<Item>(0x13C0);
        public Item GetPlayerInvetoryProxy() => ReadPointerStruct<Item>(0x1450);
        public Item GetClientSkinInfoData() => ReadPointerStruct<Item>(0x1458);
        public Item GetLoopbackPacketSender() => ReadPointerStruct<Item>(0x1458);
        public Item GetInventory() => ReadPointerStruct<Item>(0x15E0);
        public Item GetClientInstance() => ReadPointerStruct<Item>(0x15E0);
        public Item GetDataItem() => ReadPointerStruct<Item>(0x1678);
        public Item GetItem() => ReadPointerStruct<Item>(0x1680);
    }
}
