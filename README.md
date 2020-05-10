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


## Filling

Description

###  Filling Object

Description

```
 public class TestClass
 {
    public string Name     { get; set; }
    public string Surname  { get; set; }
    public ushort Checksum { get; set; }
 }
 
 ChecksumCalculator checksumCalculator = new ChecksumCalculator();

 TestClass testClass = new TestClass()
 {
    Name     = "Hidayet Raşit",
    Surname  = "ÇÖLKUŞU",
    Checksum = 0
 };

 testClass = checksumCalculator.Fill(testClass); 
 Result: testClass.Checksum : 46781
```

###  Filling Json

Description

```
 ChecksumCalculator checksumCalculator = new ChecksumCalculator();

 string json = @"{""Name"":""Hidayet Raşit"",""Surname"":""ÇÖLKUŞU""}";

 json = checksumCalculator.Fill(json);
 Result: {"Name":"Hidayet Raşit","Surname":"ÇÖLKUŞU","Checksum":43460}
```

```
 ChecksumCalculator checksumCalculator = new ChecksumCalculator();

 string json = @"{""Name"":""Hidayet Raşit"",""Surname"":""ÇÖLKUŞU"",""Checksum"":0}";

 json = checksumCalculator.Fill(json);
 Result: {"Name":"Hidayet Raşit","Surname":"ÇÖLKUŞU","Checksum":46781}
```

###  Filling Byte Array

Description

```
 ChecksumCalculator checksumCalculator = new ChecksumCalculator();

 byte[] bytes = new byte[] { 0, 1, 2, 3, 0, 0 };

 bytes = checksumCalculator.Fill(bytes, 4);
 Result: { 0, 1, 2, 3, 204, 120 }
```


##  Comparing Checksum

Description


###  Comparing Object Checksum

Description

```
```

###  Comparing Json Checksum

Description

```
```

###  Comparing Byte Array Checksum

Description

```
```
