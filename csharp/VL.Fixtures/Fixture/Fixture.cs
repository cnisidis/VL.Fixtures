

namespace VL.Fixtures.Fixture
{
    public partial class Fixture : IFixture
    {
        public FixtureDefinition FixtureDefinition { get; private set; }
        public int Offset;
        public Fixture? Parent;
        public int Mode;
        public int Size;

        public int[] Universes;
        public Fixture(Fixture? Parent)
        {
            if(Parent != null)
            {
                this.Parent = Parent;
                if (this.Offset < this.Parent.Offset + Parent.Size)
                {
                    this.Offset += Parent.Offset + Parent.Size;
                }
            }

            if(this.FixtureDefinition != null)
            {
                this.Size = FixtureDefinition.Modes.FirstOrDefault().ChannelsCount;
            }
        }

        public int GetSize() => FixtureDefinition.Modes[Mode].ChannelsCount == null ? 0 : FixtureDefinition.Modes[Mode].ChannelsCount;

        public static Fixture FromDefinition(FixtureDefinition Definition)
        {
            var fixture = new Fixture(null);
            fixture.FixtureDefinition = Definition;

            return fixture;
                
           
        }
        

        public void SetMode(int Index)
        {
            this.Mode = Index;
        }


        public void Split(out int Offset, out int Size, out Mode Mode)
        {
            Offset = this.Offset;
            Size = this.Size;
            Mode = this.FixtureDefinition.Modes[this.Mode];
        }

        public void SetDefinition(FixtureDefinition Definition)
        { 
            this.FixtureDefinition = Definition;
        }
    }
}
