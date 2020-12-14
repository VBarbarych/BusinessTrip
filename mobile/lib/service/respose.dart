import 'dart:io';

import 'package:assignments/service/http.dart';
import 'package:path_provider/path_provider.dart';

class ResponseService {
  Future<String> ukrResponse() async {
    File file;
    try {
      var response = await HttpService.post("", {});
      Directory appDocDirectory = await getApplicationDocumentsDirectory();
      String appDocumentsPath = appDocDirectory.path;
      String filePath = '$appDocumentsPath/ukr.pdf';
      file = File(filePath);
      if (!file.existsSync()) file.create();
      await file.writeAsBytes(response.data);
    } catch (e) {}
    return file.path;
  }

  Future<String> eurResponse() async {
    File file;
    try {
      var response = await HttpService.post("", {});
      Directory appDocDirectory = await getApplicationDocumentsDirectory();
      String appDocumentsPath = appDocDirectory.path;
      String filePath = '$appDocumentsPath/eur.pdf';
      file = File(filePath);
      if (!file.existsSync()) file.create();
      await file.writeAsBytes(response.data);
    } catch (e) {}
    return file.path;
  }
}
