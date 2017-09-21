using System.Data.SqlTypes;

namespace AppMultisport {

    public class EditedDept : Dept {

        public bool Added { get; set; } = false;
        public bool Renamed { get; set; } = false;

        public EditedDept(SqlInt32 ID, string name, string shortName) : base(ID, name, shortName) {
        }

        public EditedDept(string name, string shortName) : base(0, name, shortName) {
            Added = true;
        }

        public EditedDept(Dept deptToEdit) : base(deptToEdit.DepartmentID, deptToEdit.Name, deptToEdit.ShortName) {
        }

    }

}
