import 'package:animator/animator.dart';
import 'package:assignments/model/datetime.dart';
import 'package:assignments/screens/pdf_screen.dart';
import 'package:assignments/service/respose.dart';
import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

class RequestUkrScreen extends StatefulWidget {
  @override
  _RequestUkrScreenState createState() => _RequestUkrScreenState();
}

class _RequestUkrScreenState extends State<RequestUkrScreen> {
  TextEditingController username;

  TextEditingController unit;

  TextEditingController purpose;
  TextEditingController payment;
  TextEditingController outlay;
  TextEditingController city;
  TextEditingController transport;
  TextEditingController institution;
  TextEditingController datefrom;
  TextEditingController route;
  TextEditingController reason;
  DateTime selectedDate;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('Відрядження в Україні')),
      resizeToAvoidBottomPadding: false,
      body: SingleChildScrollView(
        child: Container(
          padding: EdgeInsets.all(15),
          child: Column(children: [
            TextField(
              autofocus: false,
              keyboardType: TextInputType.visiblePassword,
              controller: username,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  labelStyle: TextStyle(color: Colors.grey, fontSize: 11),
                  labelText:
                      "Ваше прізвище, ім'я, по- батькові (в родовому відмінку)"),
            ),
            SizedBox(
              height: 10,
            ),
            TextField(
              autofocus: false,
              keyboardType: TextInputType.visiblePassword,
              controller: unit,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  labelStyle: TextStyle(color: Colors.grey, fontSize: 11),
                  labelText:
                      "Вкажіть підрозділ та посаду за основним місцем праці"),
            ),
            SizedBox(
              height: 10,
            ),
            TextField(
              autofocus: false,
              keyboardType: TextInputType.visiblePassword,
              controller: purpose,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  labelStyle: TextStyle(color: Colors.grey, fontSize: 11),
                  labelText: "Вкажіть мету відрядження"),
            ),
            SizedBox(
              height: 10,
            ),
            TextField(
                autofocus: false,
                keyboardType: TextInputType.visiblePassword,
                controller: payment,
                decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    labelStyle: TextStyle(color: Colors.grey, fontSize: 11),
                    labelText: "Вкажіть вид збереження заробітної плати")),
            SizedBox(
              height: 10,
            ),
            TextField(
              autofocus: false,
              keyboardType: TextInputType.visiblePassword,
              controller: city,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  labelStyle: TextStyle(color: Colors.grey, fontSize: 11),
                  labelText: "Вкажіть місто відрядження"),
            ),
            SizedBox(
              height: 10,
            ),
            TextField(
              autofocus: false,
              keyboardType: TextInputType.visiblePassword,
              controller: institution,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  labelStyle: TextStyle(color: Colors.grey, fontSize: 11),
                  labelText: "Вкажіть установу, куди відряджаєтесь"),
            ),
            SizedBox(
              height: 10,
            ),
            TextField(
              autofocus: false,
              keyboardType: TextInputType.visiblePassword,
              controller: institution,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  labelStyle: TextStyle(color: Colors.grey, fontSize: 11),
                  labelText: "Вкажіть установу, куди відряджаєтесь"),
            ),
            SizedBox(
              height: 10,
            ),
            MyTextFieldDatePicker(
              labelText: "Дата початку відрядження",
              labelStyle: TextStyle(color: Colors.grey, fontSize: 11),
              prefixIcon: Icon(Icons.date_range),
              suffixIcon: Icon(Icons.arrow_drop_down),
              lastDate: DateTime.now().add(Duration(days: 366)),
              firstDate: DateTime.now(),
              initialDate: DateTime.now().add(Duration(days: 1)),
              onDateChanged: (selectedDate) {
                // Do something with the selected date
              },
            ),
            SizedBox(
              height: 10,
            ),
            MyTextFieldDatePicker(
              labelText: "Дата закінчення відрядження",
              labelStyle: TextStyle(color: Colors.grey, fontSize: 11),
              prefixIcon: Icon(Icons.date_range),
              suffixIcon: Icon(Icons.arrow_drop_down),
              lastDate: DateTime.now().add(Duration(days: 366)),
              firstDate: DateTime.now(),
              initialDate: DateTime.now().add(Duration(days: 1)),
              onDateChanged: (selectedDate) {
                // Do something with the selected date
              },
            ),
            SizedBox(
              height: 10,
            ),
            TextField(
              autofocus: false,
              keyboardType: TextInputType.visiblePassword,
              controller: route,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  labelStyle: TextStyle(color: Colors.grey, fontSize: 11),
                  labelText:
                      "Вкажіть маршрут поїздки, наприклад: Львів-Київ-Львів"),
            ),
            SizedBox(
              height: 10,
            ),
            TextField(
              autofocus: false,
              keyboardType: TextInputType.visiblePassword,
              controller: transport,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  labelStyle: TextStyle(color: Colors.grey, fontSize: 11),
                  labelText: "Вкажіть транспорт, яким будете подорожувати"),
            ),
            SizedBox(
              height: 10,
            ),
            TextField(
              autofocus: false,
              keyboardType: TextInputType.visiblePassword,
              controller: outlay,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  labelStyle: TextStyle(color: Colors.grey, fontSize: 11),
                  labelText:
                      "Як буде здійснюватись оплата видатків на відрядження"),
            ),
            SizedBox(
              height: 10,
            ),
            TextField(
              autofocus: false,
              keyboardType: TextInputType.visiblePassword,
              controller: reason,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  labelStyle: TextStyle(color: Colors.grey, fontSize: 11),
                  labelText: "Вкажіть підставу відрядження"),
            ),
            SizedBox(
              height: 20,
            ),
            MaterialButton(
                child: Container(
                    width: 180,
                    height: 54,
                    child: Container(
                      padding: EdgeInsets.only(top: 15),
                      child: Text('Запит',
                          textAlign: TextAlign.center,
                          style: GoogleFonts.roboto(
                              fontSize: 18,
                              color: Colors.white,
                              fontWeight: FontWeight.bold)),
                    ),
                    decoration: BoxDecoration(
                        color: Colors.blue,
                        borderRadius: BorderRadius.circular(5.0))),
                onPressed: () async {
                  // String filePdf = await ResponseService().ukrResponse();
                  // Navigator.push(
                  //     context,
                  //     MaterialPageRoute(
                  //         builder: (context) =>
                  //             PdfScreen(filePdf, username.text)));
                  return showDialog<void>(
      context: context,
      barrierDismissible: false,
      builder: (ctx) {
        return Scaffold(
          backgroundColor: Colors.white,
          body: Container(
            child: SafeArea(
              child: Container(
                width: double.infinity,
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: <Widget>[
                    Animator(
                      tween: Tween<double>(begin: 0, end: 6.28),
                      duration: Duration(seconds: 5),
                      repeats: 5,
                      builder: (anim) => Transform(
                        transform: Matrix4.rotationZ(anim.value),
                        alignment: Alignment.center,
                        child: Image.asset('assets/bus.png',width: 200,)
                    
                      ),
                    ),
                  ],
                ),
              ),
            ),
          ),
        );
      },
    
    );
                })
          ]),
        ),
      ),
    );
  }
  
 
}

