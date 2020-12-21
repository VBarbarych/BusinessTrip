import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

class RequestScreen extends StatelessWidget{
  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.only(
          top: 60,
          left: MediaQuery.of(context).size.width / 30,
          right: MediaQuery.of(context).size.width / 30),
      child: Column(
        children: [
          Container(
              child: Text('Зробити запит',
                  style: GoogleFonts.roboto(
                      fontSize: 30,
                      color: Colors.black,
                      fontWeight: FontWeight.normal)),
              alignment: Alignment.centerLeft),
          SizedBox(
            height: 10,
          ),
          Container(
              child: Text('Будь ласка оберіть тип запиту',
                  style: GoogleFonts.roboto(
                      fontSize: 15,
                      color: Colors.grey,
                      fontWeight: FontWeight.normal)),
              alignment: Alignment.centerLeft),
          SizedBox(height: 120),
          SizedBox(
            height: 200,
            child: Row(
                mainAxisSize: MainAxisSize.max,
                crossAxisAlignment: CrossAxisAlignment.stretch,
                children: [
                  Expanded(
                      child: GestureDetector(
                          onTap: () =>
                              Navigator.of(context).pushNamed('/requestukr'),
                          child: Container(
                            decoration: BoxDecoration(
                              borderRadius: BorderRadius.circular(9.0),
                              color: Colors.white,
                            ),
                            child: Column(
                              mainAxisSize: MainAxisSize.max,
                              mainAxisAlignment: MainAxisAlignment.center,
                              children: [
                                Image.asset('assets/2.png',
                                    height: 100, width: 100)
                              ],
                            ),
                          ))),
                  SizedBox(
                    width: 16,
                  ),
                  Expanded(
                      child: GestureDetector(
                          onTap: () =>
                              Navigator.of(context).pushNamed('/requesteur'),
                          child: Container(
                            decoration: BoxDecoration(
                              borderRadius: BorderRadius.circular(9.0),
                              color: Colors.white,
                            ),
                            child: Column(
                              mainAxisSize: MainAxisSize.max,
                              mainAxisAlignment: MainAxisAlignment.center,
                              children: [
                                Image.asset('assets/3.png',
                                    height: 100, width: 100)
                              ],
                            ),
                          )))
                ]),
          ),
          SizedBox(height: 20),
          Row(
            children: [
              Container(
                  padding: EdgeInsets.only(
                      left: MediaQuery.of(context).size.width / 55),
                  width: MediaQuery.of(context).size.width / 2.4,
                  child: Text(
                    'ВІДРЯДЖЕННЯ В УКРАЇНІ',
                    style: GoogleFonts.roboto(
                        fontSize: 13,
                        fontWeight: FontWeight.bold,
                        color: Colors.grey),
                    textAlign: TextAlign.center,
                  )),
              SizedBox(
                width: MediaQuery.of(context).size.width / 13,
              ),
              Container(
                width: 150,
                padding: EdgeInsets.only(
                    left: MediaQuery.of(context).size.width / 27),
                alignment: Alignment.topLeft,
                child: Text("ВІДРЯДЖЕННЯ ЗАКОРДОНОМ",
                    style: GoogleFonts.roboto(
                      fontSize: 13,
                      fontWeight: FontWeight.bold,
                      color: Colors.grey,
                    ),
                    textAlign: TextAlign.center),
              )
            ],
          ),
        ],
      ),
    );
  }
}
