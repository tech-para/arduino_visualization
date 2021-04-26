#include<stdlib.h>
static int i=0;
void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);

}

void loop() {
  // put your main code here, to run repeatedly:
  char str[16]="";
  sprintf(str,"%d",i);
  Serial.println(str);
  delay(1000);
  i++;
}
