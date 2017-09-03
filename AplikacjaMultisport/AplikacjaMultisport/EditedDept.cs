using System.Data.SqlTypes;

namespace AppMultisport {

    public class EditedDept : Dept {

        public bool Added { get; set; } = false;
        public bool Renamed { get; set; } = false;

        public EditedDept(SqlInt32 ID, string name) : base(ID, name) {
        }

        public EditedDept(string name) : base(0, name) {
            Added = true;
        }

        public EditedDept(Dept deptToEdit) : base(deptToEdit.DepartmentID, deptToEdit.Name) {
        }

    }

}
