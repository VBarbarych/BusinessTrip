import 'package:assignments/screens/request_eur.dart';
import 'package:assignments/screens/request_ukr.dart';
import 'package:flutter/material.dart';

final appRoutes = {
  '/requestukr': (BuildContext context) => new RequestUkrScreen(),
  '/requesteur': (BuildContext context) => new RequestEurScreen()
};
