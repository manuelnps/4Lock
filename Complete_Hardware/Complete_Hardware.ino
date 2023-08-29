#include <LiquidCrystal_I2C.h>
#include <SPI.h>
#include <MFRC522.h>

#define SS_PIN 5
#define RST_PIN 4

String UID[] = {
  "A9 56 6F 72", // Cartão Bruna
  "49 E9 DD 71"  // Cartão Manuel
};

// Pinos para controlar o relé
const int relayPin = 2;

LiquidCrystal_I2C lcd(0x3F, 16, 2);
MFRC522 rfid(SS_PIN, RST_PIN);

void setup() {
  Serial.begin(9600);
  
  lcd.init();
  lcd.backlight();
  
  SPI.begin();
  rfid.PCD_Init();

  pinMode(relayPin, OUTPUT); // Configurar o pino do relé como saída
  digitalWrite(relayPin, LOW); // Inicialmente, mantenha o relé desativado
}

void loop() {
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
  for (int i = 0; i < sizeof(UID) / sizeof(UID[0]); i++) {
    if (ID.substring(1) == UID[i]) {
      accessGranted = true;
      break;
    }
  }

  if (accessGranted) {
  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print(" Cacifo aberto");
  
  digitalWrite(relayPin, HIGH); // Ativar o relé para abrir a fechadura
  delay(7000);
  
  digitalWrite(relayPin, LOW); // Desativar o relé
  
  delay(2000); // Aguardar antes de limpar o LCD
  lcd.clear();
} else {
  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print(" Acesso negado");
  delay(1500);
  lcd.clear();
  }
}