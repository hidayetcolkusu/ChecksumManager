# ChecksumManager

Description

## Object Conversion

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

 byte[] bytes = checksumCalculator.GetByteArray(testClass); 
```

## Checksum Calculation

Description

###  Object Checksum Calculation

Description

``` 
 ChecksumCalculator checksumCalculator = new ChecksumCalculator();

 TestClass testClass = new TestClass()
 {
    Name    = "Hidayet Raşit",
    Surname = "ÇÖLKUŞU"
 };

 ushort checksum = checksumCalculator.Calculate(testClass);
 Result: 43460
```


###  Json Checksum Calculation

Description

```
 ChecksumCalculator checksumCalculator = new ChecksumCalculator();
                        
 string json = @"{""Name"":""Hidayet Raşit"",""Surname"":""ÇÖLKUŞU""}";

 ushort checksum = checksumCalculator.Calculate(json);
 Result: 43460
```

###  Byte Array Checksum Calculation

Description

```
 ChecksumCalculator checksumCalculator = new ChecksumCalculator();
                        
 byte[] bytes = new byte[] { 0, 1, 2, 3, 4 };

 ushort checksum = checksumCalculator.Calculate(bytes);
 Result: 4001
```
