

namespace VL.Fixtures.Fixture
{
    public partial class Field
    {
        /// <summary>
        /// DMX Channels (offsets)
        /// </summary>
        public List<int> DMXChannels;
        public FieldType Type;
        /// <summary>
        /// Groups where the field belongs to
        /// </summary>
        public HashSet<int> Groups;
        public int Size { get; set; }

        public int Offset;

        public object DefaultValue;

        public string Name;

        public Field(string Name, FieldType Type, int Offset, int Size)
        {
            this.Name = Name;
            this.DMXChannels = new List<int>();
            this.Size = Size;
            this.Offset = Offset;

            for (int i = 0; i < Size; i++)
            {
                DMXChannels.Add(i + Offset);
            }
        }


        public int GetSize() => DMXChannels.Count;

        public void Split(out string Name, out int Offset, out int Size)
        {
            Name = this.Name;
            Offset = this.Offset;
            Size = this.Size;
        }

        public Spread<int> GetChannels()
        {
            return this.DMXChannels.ToSpread();
        }


        public Spread<byte> ToBytes()
        {
            return new byte[] {0} .ToSpread();
        }

        private int SizeFromType()
        {
            int size = 1;
            if(this.Size ==0)
            {
                switch (this.Type)
                {
                    case FieldType.Float:
                        size = 2;
                        break;
                    case FieldType.RGBW:
                        size = 4;
                        break;
                    case FieldType.SingleColor:
                        size = 1;
                        break;
                    case FieldType.List:
                        size = 4;
                        break;
                }
            }
            else
            {
                size = this.Size;
            }
            return size;
        }
    }


    public enum FieldType
    {
        Float,
        Int,
        RGBW,
        SingleColor,
        AdditiveColor,
        List,
    }

    public enum FixedSize
    {
        None,
        One,
        Two,
        Four,

    }
}
