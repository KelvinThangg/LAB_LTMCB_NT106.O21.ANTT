using System;
using System.IO;

namespace ReadWriteFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"C:\Users\dadad\Downloads\Compressed\Input.txt";
            string outputFilePath = @"C:\Users\dadad\Downloads\Compressed\Output.txt";
            // Kiểm tra file input có tồn tại
            if (!File.Exists(inputFilePath))
            {
                // Tạo mới file input rỗng
                File.Create(inputFilePath);
            }

            // Xoá sạch nội dung file output
            File.WriteAllText(outputFilePath, string.Empty);

            // Đọc từng dòng trong file input
            string[] lines = File.ReadAllLines(inputFilePath);

            // Mở file output để ghi
            using (StreamWriter outputFile = new StreamWriter(outputFilePath))
            {
                foreach (string line in lines)
                {
                    // Kiểm tra số lượng dấu cách
                    int spaceCount = line.Split(' ').Length - 1;
                    if (spaceCount != 1)
                    {
                        outputFile.WriteLine($"{line} - Lỗi định dạng");
                        continue;
                    }
                    // Loại bỏ dấu cách không cần thiết
                    string formattedLine = line.Replace(" ", "");

                    // Tách các phần tử trong dòng
                    string[] parts = formattedLine.Split(new[] { '+', '-', '*', '/' });

                    // Kiểm tra định dạng của phần tử
                    if (parts.Length < 2)
                    {
                        outputFile.WriteLine($"{line} - Lỗi định dạng");
                        continue;
                    }

                    // Kiểm tra dấu cách trước số thứ nhất hoặc sau số thứ hai
                    if (parts[0].EndsWith(" ") || parts[1].StartsWith(" "))
                    {
                        outputFile.WriteLine($"{line} - Lỗi định dạng (không được có dấu cách trước số thứ nhất hoặc sau số thứ hai)");
                        continue;
                    }

                    // Kiểm tra định dạng
                    if (parts.Length != 2)
                    {
                        // Ghi lỗi
                        outputFile.WriteLine($"{line} - Lỗi định dạng");
                        continue;
                    }
                    // Lấy phép toán
                    string operation = formattedLine.Substring(parts[0].Length, 1);

                    // Kiểm tra num1 và num2 là số hợp lệ
                    double num1, num2;
                    if (!double.TryParse(parts[0], out num1) || !double.TryParse(parts[1], out num2))
                    {
                        // Ghi lỗi
                        outputFile.WriteLine($"{line} - Lỗi dữ liệu không hợp lệ");
                        continue;
                    }
                    // Kiểm tra num1 và num2 có chứa dấu phẩy hay không
                    bool hasDotInNum1 = parts[0].IndexOf('.') != -1;
                    bool hasDotInNum2 = parts[1].IndexOf('.') != -1;

                    // Nếu có dấu phẩy thì báo lỗi
                    if (hasDotInNum1 || hasDotInNum2)
                    {
                        outputFile.WriteLine($"{line} - Lỗi định dạng (số không được phép chứa dấu \".\")");
                        continue;
                    }
                    // Chuyển đổi các phần tử sang kiểu dữ liệu phù hợp
                    // num1 = double.Parse(parts[0]);
                    //num2 = double.Parse(parts[1]);

                    // Thực hiện phép toán
                    double result = 0;
                    switch (operation)
                    {
                        case "+":
                            result = num1 + num2;
                            break;
                        case "-":
                            result = num1 - num2;
                            break;
                        case "*":
                            result = num1 * num2;
                            break;
                        case "/":
                            if (num2 == 0)
                            {
                                outputFile.WriteLine($"{line} - Lỗi chia cho 0");
                                continue;
                            }
                            result = num1 / num2;
                            break;
                        default:
                            outputFile.WriteLine($"{line} - Lỗi phép toán không hợp lệ");
                            continue;
                    }

                    // Ghi kết quả
                    outputFile.WriteLine($"{num1} {operation}{num2} = {result}");
                }
            }
        }
    }
}
