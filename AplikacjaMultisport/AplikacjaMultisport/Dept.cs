using System.Data.SqlTypes;

namespace AppMultisport {

    public class Dept {

        public SqlInt32 DepartmentID { get; set; }
        public string Name { get; set; }

        public Dept(SqlInt32 ID, string name) {
            DepartmentID = ID;
            Name = name;
        }

        public override string ToString() {
            return Name;
        }
        
    }

}