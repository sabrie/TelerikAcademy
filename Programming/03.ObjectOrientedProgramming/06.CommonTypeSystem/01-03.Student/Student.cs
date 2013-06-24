using System;
using System.Text;

// enumeration
public enum University
{
    SofiaUniversity,
    UNSS,
    TU,
    PlovdivUniversity,
    VelikoTarnovoUniversity,
    Telerik
}

// enumeration
public enum Faculty
{
    FMI,
    UF,
    Programming
}

// enumeration
public enum Specialty
{
    IIKT,
    MO,
    SoftwareEngineer
}


class Student : ICloneable, IComparable<Student>
{
    // properties
    public string FirstName { get; set;}
    public string MiddleName { get; set; }
    public string LastName{ get; set;}
    public string SSN { get; set;}
    public string PermanentAddress{ get; set;}
    public string MobilePhone{ get; set;}
    public string Email{ get; set;}
    public string Course{ get; set;}

    public University University { get; set; }
    public Faculty Faculty { get; set; }
    public Specialty Specialty { get; set; }

    // default constructor
    public Student()
    {
    }

    // constructor
    public Student(string firstName, string middleName, string lastName, string ssn, string permanentAddress = null, 
                    string mobilePhone = null, string email = null, string course = null, 
                    University university = new University(), Faculty faculty = new Faculty(), Specialty specialty = new Specialty())
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;
        this.SSN = ssn;
        this.PermanentAddress = permanentAddress;
        this.MobilePhone = mobilePhone;
        this.Email = email;
        this.Course = course;
        this.University = university;
        this.Faculty = faculty;
        this.Specialty = specialty;            
    }

    public override bool Equals(object obj)
    {
        // as the SSN number is unique - we compare students by their SSN
        // if SSN of two students is the same -> they are equal or one and the same student
        return this.SSN == (obj as Student).SSN;
    }

    public override int GetHashCode()
    {
        // again we use the SSN of student which is unique for each student
        return this.SSN.GetHashCode();
    }

    public static bool operator ==(Student a, Student b)
    {
        return Student.Equals(a, b);
    }

    public static bool operator !=(Student a, Student b)
    {
        return !(Student.Equals(a, b));
    }

    object ICloneable.Clone()  // Implicit implementation
    {
        return this.Clone();
    }

    public Student Clone()
    {
        // we make a deep copy by creating a new instance of the class Student and copy all the properties of the current student
        // to new student
        Student student = new Student();
        student.FirstName = this.FirstName;
        student.MiddleName = this.MiddleName;
        student.LastName = this.LastName;
        student.SSN = this.SSN;
        student.PermanentAddress = this.PermanentAddress;
        student.MobilePhone = this.MobilePhone;
        student.Email = this.Email;
        student.Course = this.Course;
        student.University = this.University;
        student.Faculty = this.Faculty;
        student.Specialty = this.Specialty;
      
        // return the copy of the current student
        return student;
    }

    public int CompareTo(Student other)
    {
        int compare;
        
        // we first compare by first names and if they are not equal return the result
        compare = this.FirstName.CompareTo(other.FirstName);
        if (compare != 0)
        {
            return compare;
        }

        // if their first names are equal then we compare students by their middle names 
        compare = this.MiddleName.CompareTo(other.MiddleName);
        if (compare != 0)
        {
            return compare;
        }

        // if their middle names are also equal we compare them by their Last names
        compare = this.LastName.CompareTo(other.LastName);
        if (compare != 0)
        {
            return compare;
        }
        
        // finally if their last names are also equal we compare them by their SSNs
        compare = this.SSN.CompareTo(other.SSN);
        // return the result
        return compare;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.AppendFormat("Name: {0} {1} {2}", this.FirstName, this.MiddleName, this.LastName).AppendLine();
        result.AppendFormat("Social Security Number: {0}", this. SSN).AppendLine();
        result.AppendFormat("Permanent Address: {0}", this.PermanentAddress).AppendLine();
        result.AppendFormat("Mobile Phone: {0}", this.MobilePhone).AppendLine();
        result.AppendFormat("Email: {0}", this.Email).AppendLine();
        result.AppendFormat("Course: {0}", this.Course).AppendLine();
        result.AppendFormat("University: {0}", this.University).AppendLine();
        result.AppendFormat("Faculty: {0}", this.Faculty).AppendLine();
        result.AppendFormat("Specialty: {0}", this.Specialty).AppendLine();

        return result.ToString();
    }
}
