# ChecksumManager


## Object Conversion


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
 

###  Object Checksum Calculation
 

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


```
 ChecksumCalculator checksumCalculator = new ChecksumCalculator();
                        
 string json = @"{""Name"":""Hidayet Raşit"",""Surname"":""ÇÖLKUŞU""}";

 ushort checksum = checksumCalculator.Calculate(json);
 Result: 43460
```

###  Byte Array Checksum Calculation
 

```
 ChecksumCalculator checksumCalculator = new ChecksumCalculator();
                        
 byte[] bytes = new byte[] { 0, 1, 2, 3, 4, 0, 0 };

 ushort checksum = checksumCalculator.Calculate(bytes);
 Result: 37945
```


## Filling
 

###  Filling Object
 

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
 

```
 ChecksumCalculator checksumCalculator = new ChecksumCalculator();

 byte[] bytes = new byte[] { 0, 1, 2, 3, 0, 0 };

 bytes = checksumCalculator.Fill(bytes, 4);
 Result: { 0, 1, 2, 3, 204, 120 }
```


##  Comparing Checksum



###  Comparing Object Checksum
 

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

 bool result = checksumCalculator.Compare(testClass, 46781);
 Result: true
```

``` 
 ChecksumCalculator checksumCalculator = new ChecksumCalculator();

 TestClass testClass = new TestClass()
 {
    Name     = "Hidayet Raşit",
    Surname  = "ÇÖLKUŞU",
    Checksum = 46781
 };

 bool result = checksumCalculator.Compare(testClass);
 Result: true
```

###  Comparing Json Checksum
 

```
 ChecksumCalculator checksumCalculator = new ChecksumCalculator();
             
 string json = @"{""Name"":""Hidayet Raşit"",""Surname"":""ÇÖLKUŞU""}";

 bool result = checksumCalculator.Compare(json, 43460);
 Resut:true
```

```
 ChecksumCalculator checksumCalculator = new ChecksumCalculator();
             
 string json = @"{""Name"":""Hidayet Raşit"",""Surname"":""ÇÖLKUŞU"",""Checksum"":43460}"; 

 bool result = checksumCalculator.Compare(json);
 Result:true
```

###  Comparing Byte Array Checksum
 

```
 ChecksumCalculator checksumCalculator = new ChecksumCalculator();

 byte[] bytes = new byte[] { 0, 1, 2, 3, 4, 0, 0 };

 bool result = checksumCalculator.Compare(bytes, Convert.ToUInt16(37945));
 Result:true
```

```
 ChecksumCalculator checksumCalculator = new ChecksumCalculator();

 byte[] bytes = new byte[] { 0, 1, 2, 3, 204, 120 };

 bool result = checksumCalculator.Compare(bytes, 4);
 Result:true
```

##  Checksum Attribute


```
 public class TestClass
 {
    public string Name    { get; set; }
    public string SurName { get; set; }
 }

 public class TestController : Controller
 {
    [Checksum]
    [System.Web.Http.HttpPost]
    public bool SetData([System.Web.Http.FromBody]TestClass testClass)
    {
       return true;
    }
 }
```

```
 TestClass TestClass = new TestClass()
 {
    Name    = "Hidayet Raşit",
    SurName = "ÇÖLKUŞU"
 };
                 
 HttpWebRequest request = (HttpWebRequest)
 string testLink = "https://localhost:44324/Test/SetData";
 WebRequest.Create(testLink);
 request.KeepAlive           = false;
 request.ProtocolVersion     = HttpVersion.Version10;
 request.Method              = "POST";
 byte[] postBytes            = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(TestClass));
 request.ContentType         = "application/json; charset=UTF-8";
 request.Accept              = "application/json";
 request.ContentLength       = postBytes.Length;
 request.Headers["Checksum"] = "52195";
 Stream requestStream        = request.GetRequestStream(); 
 requestStream.Write(postBytes, 0, postBytes.Length);
 requestStream.Close();

 HttpWebResponse response = (HttpWebResponse)request.GetResponse();

 using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
 {
    responseText = rdr.ReadToEnd();
 }
 Result:true
```

```
 TestClass TestClass = new TestClass()
 {
    Name    = "Hidayet Raşit",
    SurName = "ÇÖLKUŞU"
 };
                 
 HttpWebRequest request = (HttpWebRequest)
 string testLink = "https://localhost:44324/Test/SetData";
 WebRequest.Create(testLink);
 request.KeepAlive           = false;
 request.ProtocolVersion     = HttpVersion.Version10;
 request.Method              = "POST";
 byte[] postBytes            = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(TestClass));
 request.ContentType         = "application/json; charset=UTF-8";
 request.Accept              = "application/json";
 request.ContentLength       = postBytes.Length;
 request.Headers["Checksum"] = "1234";
 Stream requestStream        = request.GetRequestStream(); 
 requestStream.Write(postBytes, 0, postBytes.Length);
 requestStream.Close();

 HttpWebResponse response = (HttpWebResponse)request.GetResponse();

 using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
 {
    responseText = rdr.ReadToEnd();
 }
 Result:"HTTP Error 401.0 - Unauthorized"
```
