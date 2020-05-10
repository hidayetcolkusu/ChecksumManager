# ChecksumManager

Description

## Checksum Calculator

Description

###  Object Checksum Calculator

Description

```
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
```


###  Json Checksum Calculator

Description

```
 ChecksumCalculator checksumCalculator = new ChecksumCalculator();
                        
 string json = @"{""Name"":""Hidayet Raşit"",""Surname"":""ÇÖLKUŞU""}";

 ushort checksum = checksumCalculator.Calculate(json);
 Result: 43460
```

###  Byte Aray Checksum Calculator

Description

```
 ChecksumCalculator checksumCalculator = new ChecksumCalculator();
                        
 byte[] bytes = new byte[] { 0, 1, 2, 3, 4 };

 ushort checksum = checksumCalculator.Calculate(bytes);
 Result: 43460
```
