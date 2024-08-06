using System.Runtime.CompilerServices;
using WorkerSpace.Enums;

namespace WorkerSpace.Models
{
    public sealed class TaskBits
    {
        public TaskBits()
        {
            _state = 0x00000000;
        }

        private int _state;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsBitSet(CustomTaskStatus state)
        {
            return (_state & (int)state) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TaskBits SetBit(CustomTaskStatus state)
        {
            _state |= (int)state;
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TaskBits ClearBit(CustomTaskStatus state)
        {
            _state &= ~(int)state;
            return this;
        }
    }
}
