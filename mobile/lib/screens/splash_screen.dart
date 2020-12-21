import 'dart:async';

import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';


import 'login_screen.dart';

class SplashScreen extends StatefulWidget {
  @override
  _SplashScreenState createState() => _SplashScreenState();
}

class _SplashScreenState extends State<SplashScreen> {
  String intro;
  @override
  void initState() {
    super.initState();
    Timer(Duration(seconds: 3), () {
      Navigator.of(context)
          .pushReplacement(MaterialPageRoute(builder: (BuildContext context) {
        return LoginScreen();
          
      }));
    });
  }

  

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        backgroundColor: Colors.white,
        body: Stack(children: [
          Positioned(
              child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Container(
                  alignment: Alignment.center,
                  child: Image.asset('assets/assignments.png'),width: 200,height: 200,),
              Container(
                  alignment: Alignment.center,
                  child: Text('ВІДРЯДЖЕННЯ',
                      style: GoogleFonts.roboto(
                        fontSize: 30,
                        color: Colors.black,
                        fontWeight: FontWeight.w300,
                      ))),
              SizedBox(
                height: 10,
              ),
              
            ],
          )),
         
        ]));
  }
}
