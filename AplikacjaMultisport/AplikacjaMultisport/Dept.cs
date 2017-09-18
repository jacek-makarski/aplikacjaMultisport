using System.Data.SqlTypes;

namespace AppMultisport {

    public class Dept {

        public SqlInt32 DepartmentID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; } = string.Empty;

        public Dept(SqlInt32 ID, string name) {
            DepartmentID = ID;
            Name = name;
            ShortName = name;
        }

        public Dept(SqlInt32 ID, string name, string shortName) {
            DepartmentID = ID;
            Name = name;
            ShortName = shortName;
        }

        public override string ToString() {
            return Name;
        }
        
    }

}