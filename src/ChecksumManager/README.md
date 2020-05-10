# ChecksumManager
 
 Checksum Calculator
 

 
 Object Checksum Calculator
  
 public class TestClass
 {
    public string Name    { get; set; }
    public string Surname { get; set; }
 } 
 
 ChecksumCalculator checksumCalculator = new ChecksumCalculator();

 TestClass testClass = new TestClass()
 {
    Name    = "Hidayet Raşit",
    Surname = "ÇÖLKUŞU"
 };

 ushort checksum = checksumCalculator.Calculate(testClass);
 Result: 43460
 
 Json Checksum Calculator
 
 Byte Aray Checksum Calculator
 

