using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace LAB2
{
    public partial class BFormatter : Form
    {
        private List<Student> students = new List<Student>();

        public BFormatter()
        {
            InitializeComponent();
        }
        private void phoneTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearTxt_Click(object sender, EventArgs e)
        {
            idTxt.Clear();
            nameTxt.Clear();
            phoneTxt.Clear();
            mathTxt.Clear();
            litrTxt.Clear();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            try
            {
                clearTxt_Click(sender, e);
                File.Delete("input4.txt");
                File.Delete("output4.txt");
                File.Delete("output_bin4.txt");
                showTxt.Clear();
                MessageBox.Show("Đã xóa dữ liệu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa dữ liệu: " + ex.Message);
            }
        }
        private void writeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin sinh viên từ form và thêm vào danh sách
                Student student = new Student
                {
                    Name = nameTxt.Text,
                    StudentID = idTxt.Text,
                    Phone = phoneTxt.Text,
                    Marks = new float[]
                    {
                        float.Parse(mathTxt.Text),
                        float.Parse(litrTxt.Text)
                    }
                };

                // Ghi thông tin sinh viên vào tệp tin input.txt sử dụng BinaryFormatter
                using (FileStream fs = new FileStream("input4.txt", FileMode.Append))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, student);
                }

                MessageBox.Show("Đã lưu thông tin sinh viên thành công vào input4.txt!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi ghi vào tệp tin: " + ex.Message);
            }
        }

        private void readBtn_Click(object sender, EventArgs e)
        {
            try
            {
                students.Clear(); // Xóa dữ liệu cũ

                // Đọc danh sách sinh viên từ tệp tin input.txt bằng BinaryFormatter
                using (FileStream fs = new FileStream("input4.txt", FileMode.OpenOrCreate))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    while (fs.Position < fs.Length)
                    {
                        Student student = (Student)formatter.Deserialize(fs);
                        students.Add(student);
                    }
                }

                // Tính điểm trung bình cho từng sinh viên
                foreach (var student in students)
                {
                    student.AverageMark = student.Marks.Average();
                }

                // Ghi thông tin sinh viên và điểm trung bình vào tệp output.txt
                using (FileStream fs = new FileStream("output_bin4.txt", FileMode.OpenOrCreate))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    foreach (var student in students)
                    {
                        formatter.Serialize(fs, student);
                    }
                }

                using (StreamWriter writer = new StreamWriter("output4.txt"))
                {
                    foreach (var student in students)
                    {
                        writer.WriteLine(student.StudentID);
                        writer.WriteLine(student.Name);
                        writer.WriteLine(student.Phone);
                        writer.WriteLine(student.Marks[0]);
                        writer.WriteLine(student.Marks[1]);
                        writer.WriteLine(student.AverageMark);
                        writer.WriteLine(); // Khoảng trắng giữa các sinh viên
                    }
                }

                // Hiển thị thông tin sinh viên trên TextBox
                DisplayStudentsOnTextBox(students);

                MessageBox.Show("Đã đọc và hiển thị thông tin sinh viên từ input.txt, " +
                                "đã ghi vào file output.txt và output_bin.txt!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi đọc từ tệp tin: " + ex.Message);
            }
        }

        private void DisplayStudentsOnTextBox(List<Student> students)
        {
            showTxt.Clear(); // Xóa nội dung hiện tại của TextBox trước khi hiển thị dữ liệu mới

            foreach (var student in students)
            {
                // Tạo chuỗi định dạng thông tin sinh viên
                StringBuilder studentInfo = new StringBuilder();
                studentInfo.AppendLine(student.StudentID);
                studentInfo.AppendLine(student.Name);
                studentInfo.AppendLine(student.Phone);
                studentInfo.AppendLine(student.Marks[0].ToString());
                studentInfo.AppendLine(student.Marks[1].ToString());
                studentInfo.AppendLine(student.AverageMark.ToString());
                studentInfo.AppendLine(); // Khoảng trắng giữa các sinh viên

                // Thêm thông tin sinh viên vào TextBox
                showTxt.AppendText(studentInfo.ToString());
            }
        }

        [Serializable]
        public class Student
        {
            public string Name { get; set; }
            public string StudentID { get; set; }
            public string Phone { get; set; }
            public float[] Marks { get; set; }
            public float AverageMark { get; set; }
        }
    }
}
