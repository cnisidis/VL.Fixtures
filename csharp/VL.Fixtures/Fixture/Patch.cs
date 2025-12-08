using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Fixtures.Fixture
{
    public class Patch
    {
        List<IFixture> Fixtures = new List<IFixture>();
        public int StartingUniverse;
        public int Offset;



        public Patch(int Universe, int Offset, Spread<IFixture> Fixtures)
        {
            StartingUniverse = Universe;
            Offset = Offset;

            this.Fixtures = Fixtures.ToList();
        }

        public Patch (string PatchCode, Spread<IFixture> Fixtures)
        {
            if(PatchCode.Contains("."))
            {
                StartingUniverse = int.Parse(PatchCode.Split(".")[0]);
                Offset = int.Parse(PatchCode.Split(".")[1]);
            }
            else
            {
                StartingUniverse = int.Parse (PatchCode);
                Offset = 1;
            }
            
        }

        public void Init()
        {
            var sizeOffset = 0;
            foreach(var fixture in this.Fixtures)
            {
                sizeOffset += fixture.GetSize();
            }
        }


    }
}
