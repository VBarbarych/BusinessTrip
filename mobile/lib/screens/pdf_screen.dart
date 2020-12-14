import 'package:flutter/material.dart';
import 'package:flutter_full_pdf_viewer/flutter_full_pdf_viewer.dart';
import 'package:share/share.dart';

class PdfScreen extends StatefulWidget {
  final String filepath;
  final String filename;
  PdfScreen(this.filepath,this.filename);
  @override
  _PdfScreenState createState() => _PdfScreenState();
}

class _PdfScreenState extends State<PdfScreen> {
  @override
  void initState() {
    super.initState();
  }

  Widget build(BuildContext context) {
    return WillPopScope(
        onWillPop: () {
          Navigator.of(context).popUntil((route) => route.isFirst);
          return Future.value(false);
        },
        child: PDFViewerScaffold(
            appBar: AppBar(
              title: Text(widget.filename),
              actions: <Widget>[
                IconButton(
                  icon: Icon(Icons.share),
                  onPressed: () async {
                    await Share.shareFiles([widget.filepath]);
                  },
                ),
              ],
            ),
            path: widget.filepath));
  }
}