using System.Collections.Generic;

namespace NapilnikStore
{
    public interface IGoodReserve
    {
        public void Reserve(List<ItemPosition> itemPositions);
    }
}
