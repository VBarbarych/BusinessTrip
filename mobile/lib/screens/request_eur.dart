import 'package:animator/animator.dart';
import 'package:assignments/model/datetime.dart';
import 'package:assignments/model/request_urkmodel.dart';
import 'package:assignments/screens/pdf_screen.dart';
import 'package:assignments/service/dataeur.dart';
import 'package:assignments/service/respose.dart';
import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

class RequestEurScreen extends StatefulWidget {
  @override
  _RequestEurScreenState createState() => _RequestEurScreenState();
}

class _RequestEurScreenState extends State<RequestEurScreen> {
  TextEditingController username = new TextEditingController();
  bool loading;
  TextEditingController unit = new TextEditingController();

  TextEditingController purpose = new TextEditingController();
  TextEditingController payment = new TextEditingController();
  TextEditingController department = new TextEditingController();
  TextEditingController outlay = new TextEditingController();
  TextEditingController city = new TextEditingController();
  TextEditingController country = new TextEditingController();

  TextEditingController institution = new TextEditingController();
  String dateform = '';
  String dateto = '';
  
  TextEditingController reason = new TextEditingController();
  DateTime selectedDate;
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();
  onLogin(RequestUrkModel request) {
    if (_formKey.currentState.validate()) {
      _formKey.currentState.save();
      DataUserEurService().createFile();
      DataUserEurService().saveFile(request);
      DataUserEurService().readFile(context);
    }
     setState(() {
        loading = true;
      });
      showDialog(
          context: context,
          builder: (BuildContext context) => AlertDialog(
              shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.all(Radius.circular(12.0))),
              title: Text(
                "Успішно",
                style: GoogleFonts.roboto(
                    color: Colors.black,
                    fontWeight: FontWeight.w500,
                    fontSize: 24),
              ),
              content: Text("Ваш запит відправлено.",
                  style: GoogleFonts.roboto(
                      color: Colors.grey,
                      fontWeight: FontWeight.w400,
                      fontSize: 15))));
    
  }
   @override
  void initState() {
    super.initState();
    loading = false;
  }
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('Відрядження закордоном')),
      resizeToAvoidBottomPadding: false,
      body: !loading
            ?SingleChildScrollView(
        child: Form(
            key: _formKey,
            autovalidate: true,child:Container(
          padding: EdgeInsets.all(15),
          child: Column(children: [
             TextFormField(
                  autofocus: false,
                  validator: validateField,
              keyboardType: TextInputType.text,
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
            TextFormField(
                  autofocus: false,
                  validator: validateField,
              keyboardType: TextInputType.text,
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
                TextFormField(
                  autofocus: false,
                  keyboardType: TextInputType.text,
                  controller: department,
                  decoration: InputDecoration(
                      border: OutlineInputBorder(),
                      labelStyle: TextStyle(color: Colors.grey, fontSize: 11),
                      labelText:
                          "Вкажіть відділ та посаду за сумісництвом (за наявності)"),
                ),
            SizedBox(
              height: 10,
            ),
            TextFormField(
              autofocus: false,
              validator: validateField,
              keyboardType: TextInputType.text,
              controller: purpose,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  labelStyle: TextStyle(color: Colors.grey, fontSize: 11),
                  labelText: "Вкажіть мету відрядження"),
            ),
            SizedBox(
              height: 10,
            ),
            TextFormField(
                  autofocus: false,
                  validator: validateField,
                keyboardType: TextInputType.text,
                controller: payment,
                decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    labelStyle: TextStyle(color: Colors.grey, fontSize: 11),
                    labelText: "Вкажіть вид збереження заробітної плати")),
            SizedBox(
              height: 10,
            ),
            TextFormField(
                  autofocus: false,
                  validator: validateField,
              keyboardType: TextInputType.text,
              controller: city,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  labelStyle: TextStyle(color: Colors.grey, fontSize: 11),
                  labelText: "Вкажіть місто відрядження"),
            ),
            SizedBox(
              height: 10,
            ),
            TextFormField(
                  autofocus: false,
                  validator: validateField,
              keyboardType: TextInputType.text,
              controller: country,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  labelStyle: TextStyle(color: Colors.grey, fontSize: 11),
                  labelText: "Вкажіть країну відрядження"),
            ),
            SizedBox(
              height: 10,
            ),
            TextFormField(
                  autofocus: false,
                  validator: validateField,
              keyboardType: TextInputType.text,
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
            TextFormField(
                  autofocus: false,
                  validator: validateField,
              keyboardType: TextInputType.text,
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
            TextFormField(
                  autofocus: false,
                  validator: validateField,
              keyboardType: TextInputType.text,
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
                  RequestUrkModel request = RequestUrkModel(
                          username: username.text,
                          unit: unit.text,
                          purpose:purpose.text,
                          payment: payment.text,
                          department: department.text,
                          outlay:outlay.text,
                          city: city.text,
                          country: country.text,
                          insitution: institution.text,
                          dateform: dateform,
                          dateto: dateto,
                          reason:reason.text);
                  onLogin(request);
                 
                  
                })
          ]),
        ),
      )):Container(
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
                                    child: Image.asset(
                                      'assets/bus.png',
                                      width: 200,
                                    )),
                              ),
                            ],
                          ),
                        ),
                      ),
                    ),
    );
  }
  String validateField(String value) {
    if (value.length < 1)
      return 'Field must be not empty';
    else
      return null;
  }
}
