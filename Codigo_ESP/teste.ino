#include <WiFi.h>
#include <HTTPClient.h>
#include <SPIFFS.h>
#include <time.h>
#include <sntp.h>
#include <LiquidCrystal_I2C.h>
#include <SPI.h>
#include <MFRC522.h>


#define SS_PIN 5
#define RST_PIN 4


LiquidCrystal_I2C lcd(0x3F, 16, 2);
MFRC522 rfid(SS_PIN, RST_PIN);


const char* ssid = "Redmi_Carol";
const char* pwd = "Carol_8226";
String URL_TAG = "http://192.168.43.169/4lock_project/readdata_TAG.php";
String URL_NMR = "http://192.168.43.169/4lock_project/readdata_NMR.php";
String URL_POS = "http://192.168.43.169/4lock_project/readdata_POS.php";
String URL_NMR_POS = "http://192.168.43.169/4lock_project/readdata_NMR_POS.php";

String rfidTAG = "";

const char* ntpServer = "pool.ntp.org";
const long gmtOffset_sec = 0; // Your GMT offset in seconds6
const int daylightOffset_sec = 3600; // Your daylight offset in seconds


void syncNTPTime() {
  configTime(gmtOffset_sec, daylightOffset_sec, ntpServer);
  Serial.println("Waiting for NTP time synchronization...");
  while (!time(nullptr)) {
    delay(1000);
    Serial.println("Waiting for NTP time...");
  }
  Serial.println("NTP time synchronized");
}

void setup() {
  Serial.begin(9600);

  connectWiFi(); //Wi-Fi initialization
  syncNTPTime(); //NTP initialization

  lcd.init();    //LCD initializations
  lcd.backlight();
  
  SPI.begin();   //rfid initializations
  rfid.PCD_Init();

  if (!SPIFFS.begin(true)) {
    Serial.println("An error occurred while mounting SPIFFS");
    while (1); // Halt the program
  }
}

void loop() {
  if (WiFi.status() != WL_CONNECTED) {
    connectWiFi();
  }

  time_t now = time(nullptr);
  struct tm* timeinfo;
  timeinfo = localtime(&now);

  /********************************Ficheiro diário*********************************************/
  if (timeinfo->tm_hour == 16 &&
      timeinfo->tm_min == 1 &&
      timeinfo->tm_sec == 00) {
      getFiles();
  }
  /********************************************************************************************/
  
  /**************************************Leitura da TAG****************************************/

  lcd.setCursor(4, 0);
  lcd.print("Bem-vindo!");
  lcd.setCursor(1, 1);
  lcd.print("Passe o cartao");

  if (!rfid.PICC_IsNewCardPresent())
    return;
  if (!rfid.PICC_ReadCardSerial())
    return;

  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print("Aguarde");
  String ID = "";
  for (byte i = 0; i < rfid.uid.size; i++) {
    lcd.print(".");
    ID.concat(String(rfid.uid.uidByte[i] < 0x10 ? " 0" : " "));
    ID.concat(String(rfid.uid.uidByte[i], HEX));
    delay(300);
  }
  ID.toUpperCase();

  bool accessGranted = false;

  int targetTAG = ID.substring(1).toInt();
  int posValue = search(targetTAG);//USAR O SEARCH()
  
  if (posValue != -1 && posValue != 9999) {
      accessGranted = true;
  }

  if (accessGranted) {
    lcd.clear();
    lcd.setCursor(0, 0);
    lcd.print(" penis circuncizado !!!!");
    lcd.setCursor(1,1);
    lcd.print(posValue);
    delay(1500);
    lcd.clear();
  } else if (posValue == 9999){
      lcd.clear();
      lcd.setCursor(0, 0);
      lcd.print(" Cacifo aberto");
      lcd.setCursor(1,1);
      lcd.print(" Zona errada");
      delay(1500);
  }else{
    lcd.clear();
    lcd.setCursor(0, 0);
    lcd.print(" Acesso negado");
    lcd.setCursor(1, 1);
    lcd.print(" N existe");
    delay(1500);
    }
    lcd.clear();
  }


   /********************************************************************************************/
  /*****************************Procura da posiçao do cacido***********************************/
  //VER ISSO
  //int NMRPos = findNMRValue(int targetTAG)
  /********************************************************************************************/
 


int search(int NMRtobeSearched){

   int NMRopen = findNMRValue(NMRtobeSearched);
   int POSValue = findPOSValue(NMRopen);
   return POSValue;

}

void getFiles(){


  deleteAllFiles();

  String payloadTAG = fetchData(URL_TAG);
  String payloadNMR = fetchData(URL_NMR);
  String payloadNMR_POS = fetchData(URL_NMR_POS);
  String payloadPOS = fetchData(URL_POS);

  if (!payloadTAG.isEmpty() && !payloadNMR.isEmpty() && !payloadNMR_POS.isEmpty() && !payloadPOS.isEmpty()) {
    saveDataToFile("/data_tag.txt", combinePayloads(payloadTAG, payloadNMR));
    saveDataToFile("/data_pos.txt", combinePayloads(payloadPOS, payloadNMR_POS));

    readAndPrintPayload("/data_tag.txt");
    readAndPrintPayload("/data_pos.txt");

  } else {
    Serial.println("Error in fetching data");
  }

}

String fetchData(String fetchURL) {
  HTTPClient http;
  http.begin(fetchURL);

  int httpCode = http.GET();
  String payload = "";
  
  if (httpCode > 0) {
    payload = http.getString();
    Serial.println("Fetched payload: " + payload);
  } else {
    Serial.println("Error in HTTP request. HTTP code: " + String(httpCode));
  }

  http.end();
  return payload;
}

void saveDataToFile(const char *filename, const String &payload) {
  File file = SPIFFS.open(filename, "w");
  if (!file) {
    Serial.println("Failed to open file for writing");
    return;
  }

  file.print(payload);

  file.close();
}

String combinePayloads(const String &payloadTAG, const String &payloadNMR) {
  String combinedData = "";
  
  int startPosTAG = 2;  // Skip the first quote and comma
  int startPosNMR = 2;  // Skip the first quote and comma

  while (true) {
    int endPosTAG = payloadTAG.indexOf('"', startPosTAG);
    int endPosNMR = payloadNMR.indexOf('"', startPosNMR);

    if (endPosTAG == -1 || endPosNMR == -1) {
      break;
    }

    String dataTAG = payloadTAG.substring(startPosTAG, endPosTAG);
    String dataNMR = payloadNMR.substring(startPosNMR, endPosNMR);

    combinedData += dataTAG + " " + dataNMR + "\n";

    startPosTAG = endPosTAG + 3;  // Skip the comma and the next quote
    startPosNMR = endPosNMR + 3;  // Skip the comma and the next quote
  }

  return combinedData;
}

String parsePayload(const String &payload) {
  String formattedData = "";

  // Split the payload by commas
  int startPos = 0;
  int endPos;
  while ((endPos = payload.indexOf(',', startPos)) != -1) {
    String data = payload.substring(startPos, endPos);
    formattedData += data + " " + String(2020 + startPos / 2) + "\n";
    startPos = endPos + 1;
  }
  // Write the last data
  String lastData = payload.substring(startPos);
  formattedData += lastData + " " + String(2020 + startPos / 2) + "\n";

  return formattedData;
}

void readAndPrintPayload(const char *filename) {
  File file = SPIFFS.open(filename, "r");
  if (!file) {
    Serial.println("Failed to open file for reading");
    return;
  }

  Serial.println("Contents of the file " + String(filename) + ":");
  while (file.available()) {
    String line = file.readStringUntil('\n');
    Serial.println(line);
  }

  file.close();
}


int findNMRValue(int targetTAG) {
  File file = SPIFFS.open("/data_tag.txt", "r");
  if (!file) {
    Serial.println("Failed to open file for reading");
    return -1; // Return a special value to indicate an error
  }

  while (file.available()) {
    String line = file.readStringUntil('\n');
    line.trim(); // Remove leading/trailing whitespace
    
    int spaceIndex = line.indexOf(' ');
    if (spaceIndex != -1) {
      int tagValue = line.substring(0, spaceIndex).toInt(); // Get the TAG value
      if (tagValue == targetTAG) {
        int nmrValue = line.substring(spaceIndex + 1).toInt(); // Get the NMR value
        file.close();
        return nmrValue;
      }
    }
  }

  file.close();
  return -1; // Return a special value to indicate that the TAG was not found
}

/*
int findNMRValue(int targetTAG) {
  File file = SPIFFS.open("/data_tag.txt", "r");
  if (!file) {
    Serial.println("Failed to open file for reading");
    return -1; // Return a special value to indicate an error
  }

  while (file.available()) {
    String line = file.readStringUntil('\n');
    line.trim(); // Remove leading/trailing whitespace
    
    int spaceIndex = line.indexOf(' ');
    if (spaceIndex != -1) {
      int tagValue = line.substring(spaceIndex + 1).toInt(); // Get the NMR value (changed from tagValue to nmrValue)
      if (tagValue == targetTAG) {
        int nmrValue = line.substring(0, spaceIndex).toInt(); // Get the TAG value (changed from nmrValue to tagValue)
        file.close();
        return nmrValue;
      }
    }
  }

  file.close();
  return -1; // Return a special value to indicate that the TAG was not found
}
*/

int findPOSValue(int targetNMR) {
  File file = SPIFFS.open("/data_pos.txt", "r");
  if (!file) {
    Serial.println("Failed to open file for reading");
    return -1; // Return a special value to indicate an error
  }

  while (file.available()) {
    String line = file.readStringUntil('\n');
    line.trim(); // Remove leading/trailing whitespace
    
    int spaceIndex = line.indexOf(' ');
    if (spaceIndex != -1) {
      int nmrValue = line.substring(spaceIndex + 1).toInt(); // Get the NMR value
      if (nmrValue == targetNMR) {
        int posValue = line.substring(0, spaceIndex).toInt(); // Get the POS value
        file.close();
        return posValue;
      }
    }
  }

  file.close();
  return -1; // Return a special value to indicate that the NMR value was not found
}

void deleteAllFiles() {
  File root = SPIFFS.open("/");
  File file = root.openNextFile();
  
  while (file) {
    if (!file.isDirectory()) {
      SPIFFS.remove(file.name());
    }
    file = root.openNextFile();
  }
}

void connectWiFi() {
  WiFi.mode(WIFI_OFF);
  delay(1000);
  // This line hides the viewing of ESP as a WiFi hotspot
  WiFi.mode(WIFI_STA);
  
  WiFi.begin(ssid, pwd);
  Serial.println("Connecting to WiFi");
  
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
    
  Serial.print("Connected to: ");
  Serial.println(ssid);
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());
}

