using Stride.Core.Extensions;

namespace VL.Fixtures.Fixture
{
    public partial class Mode
    {
        public int ChannelsCount;
        public Dictionary<string, Field> Fields { get; private set; }
        public Mode(int channelsCount)
        {
            Fields = new();
            //InitFields();
        }

        public void ClearFields()
        {
            Fields.Clear();
        }

        private void InitFields()
        {
            for (int i = 0; i < ChannelsCount; i++)
            {
                var f = new Field("",FieldType.Float, i, 1);
                this.Fields.TryAdd(f.Name, f);
            }
        }

        public void CalculateOffset()
        {
            var index = 0;
            var prevField = new Field("",FieldType.Float, 0,0);
            foreach (var field in Fields.Values)
            {
                if(field != null)
                {
                   
                    if (index > 0)
                    {
                        
                        if (prevField.Size <= field.Offset)
                        {
                            field.Offset += prevField.Size;
                            prevField = field;
                        }
                    }
                }
                
                index++;
            }

        }

        public void SetFields(Spread<Field> Fields)
        {
            foreach(var field in Fields)
            {
                var index = 0;
                if(field != null)
                {
                    if (field.Name.IsNullOrEmpty())
                        field.Name = $"Field {index}";   
                    this.Fields.TryAdd(field.Name, field);

                    index ++;
                }
            }

            //CalculateOffset();
        }

        public Spread<Field> GetFields()
        {
            return this.Fields.Values.ToSpread();
        }

        
    }
}
