

namespace VL.Fixtures.Fixture
{
    //the equivalent of Fixture Type
    public partial class FixtureDefinition
    {
        public List<Mode> Modes { get; set; }

        public string Name;
        

        public FixtureDefinition(string Name, Spread<Mode> Modes)
        {
            this.Name = Name;
            this.Modes = new();
            foreach (var Mode in Modes) { 
            
                if(Mode!=null)
                {
                    this.Modes.Add(Mode);
                    
                }
            }
        }

        public Spread<Mode> GetModes()
        {
            return this.Modes.ToSpread();
        }
    }
    
}
