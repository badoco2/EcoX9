import 'dart:io';
import 'package:eco_denuncia/pages/consultar.dart';
import 'package:eco_denuncia/pages/login.page.dart';
import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';
import 'package:path/path.dart';
import 'package:path_provider/path_provider.dart';


class ImageSave extends StatefulWidget {
  @override
  _ImageSaveState createState() => _ImageSaveState();
}

class _ImageSaveState extends State<ImageSave> {
  File _image;

  final picker = ImagePicker();

  final ButtonStyle style =
        ElevatedButton.styleFrom(
          textStyle: const TextStyle(
            fontSize: 15,
            ),
          );

  bool _isChecked1 = false;
  bool _isChecked2 = false;
  bool _isChecked3 = false;
  bool _isChecked4 = false;
  bool _isChecked5 = false;

  String _currText = '';

  List<String> text1 = ["Descarte irregular de resíduos"];
  List<String> text2 = ["Desmatamento"];
  List<String> text3 = ["Uso indevido de área pública (construções, moradia, horta, etc)"];
  List<String> text4 = ["Maus tratos contra animais"];
  List<String> text5 = ["Abandono de animais (cavalo, cachorro, gato, coelho, por exemplo)"];


  @override
  Widget build(BuildContext context) {
    
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.white,
        title: Center(
          child: Container(
            /* width: 15,
            height: 15, */
            child: Text('Informe sua denúncia',
              style: TextStyle(color: Colors.black)
            ),
          ),
        ),
        leading: Container(
          height: 40,
          width: 40,
          decoration: new BoxDecoration(
            image: new DecorationImage(
              image: AssetImage("assets/user-picture.png"),
              fit: BoxFit.fitHeight,
            ),
          ),
        ),
        actions: <Widget>[
          Container(
            width: 60,
            child: FlatButton(
              child: Icon(
                Icons.arrow_back,
                color: Color(0xFFBABABA),
              ),
              onPressed: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder: (context) => Consultar(),
                    ),
                  );
                },
            ),
          ),
        ],
      ),
      
        body: SingleChildScrollView(
          padding: EdgeInsets.only(top: 0, left: 40, right: 40),
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              SizedBox(
              height: 30,
            ),
              Center(
                child:  _image != null
          ?Container(
                  height: 300,
                  child: Padding(
                          padding: const EdgeInsets.all(8.0),
                          child: Image.file(
                            _image,
                          ),
                        ),)
                      : Padding(
                        padding: const EdgeInsets.all(50.0),
                        child: Text('Sem nenhuma foto, favor clicar no botão abaixo para registrar a ocorrência',
                          style: TextStyle(color: Colors.red, fontWeight: FontWeight.bold)
                          ), 
                        ),
                      ),
              SizedBox(
                height: 40,
                child: ElevatedButton(
                  style: style,
                  child: Text('Clique aqui para tirar uma foto da ocorrência'),
                  onPressed: _getImage,
                ),
              ),
              SizedBox(
              height: 25,),
              SizedBox(
                height: 40,
                child: ElevatedButton(
                  style: style,
                  child: Text('Clique aqui para adicionar uma foto da galeria'),
                  onPressed: _getImage1,
                ),
              ),
              SizedBox(
              height: 25,),

              //_ISCHECKED1
              SingleChildScrollView(
                child: Text(_currText,
                    style: TextStyle(
                      fontSize: 20.0,
                      fontWeight: FontWeight.bold,
                    )),
              ),
               SizedBox(
              height: 15,
              ),
              Container(  
                height: 65,
                child: Column(
                  children: text1
                      .map((t) => CheckboxListTile(
                            title: Text(t),
                            value: _isChecked1,
                            onChanged: (val) {
                              setState(() {
                                _isChecked1 = val;
                                if (val == true) {
                                  _currText = t;
                                }
                              });
                            },
                          ))
                      .toList(),
                ),
              ),

              //_ISCHECKED2
               SizedBox(
                height: 1,
              ),
              Container(
                height: 65,
                child: Column(
                  children: text2
                      .map((t) => CheckboxListTile(
                            title: Text(t),
                            value: _isChecked2,
                            onChanged: (val) {
                              setState(() {
                                _isChecked2 = val;
                                if (val == true) {
                                  _currText = t;
                                }
                              });
                            },
                          ))
                      .toList(),
                ),
              ),

            //_ISCHECKED3
             SizedBox(
              height: 1,
              ),
              Container(
                height: 65,
                child: Column(
                  children: text3
                      .map((t) => CheckboxListTile(
                            title: Text(t),
                            value: _isChecked3,
                            onChanged: (val) {
                              setState(() {
                                _isChecked3 = val;
                                if (val == true) {
                                  _currText = t;
                                }
                              });
                            },
                          ))
                      .toList(),
                ),
              ),

              //_ISCHECKED4
              SizedBox(
              height: 1,
              ),
              Container(
                height: 65,
                child: Column(
                  children: text4
                      .map((t) => CheckboxListTile(
                            title: Text(t),
                            value: _isChecked4,
                            onChanged: (val) {
                              setState(() {
                                _isChecked4 = val;
                                if (val == true) {
                                  _currText = t;
                                }
                              });
                            },
                          ))
                      .toList(),
                ),
              ),

            //_ISCHECKED5
               SizedBox(
                height: 1,
                ),
                Container(
                  height: 65,
                  child: Column(
                    children: text5
                        .map((t) => CheckboxListTile(
                              title: Text(t),
                              value: _isChecked5,
                              onChanged: (val) {
                                setState(() {
                                  _isChecked5 = val;
                                  if (val == true) {
                                    _currText = t;
                                  }
                                });
                              },
                            ))
                        .toList(),
                  ),
                ),


              SizedBox(
              height: 25,
            ),
              TextFormField(
                keyboardType: TextInputType.text,
                decoration: InputDecoration(
                  labelText: "Faça uma descrição breve da denúncia*",
                  labelStyle: TextStyle(
                  color: Colors.black38,
                  fontWeight: FontWeight.w400,
                  fontSize: 20,
                  ),
                ),
                style: TextStyle(fontSize: 20),
              ),
              SizedBox(
              height: 10,
            ),
              TextFormField(
                keyboardType: TextInputType.text,
                decoration: InputDecoration(
                  labelText: "Endereço",
                  labelStyle: TextStyle(
                  color: Colors.black38,
                  fontWeight: FontWeight.w400,
                  fontSize: 20,
                  ),
                ),
                style: TextStyle(fontSize: 20),
              ),
              SizedBox(
              height: 10,
              ),
              TextFormField(
                keyboardType: TextInputType.text,
                decoration: InputDecoration(
                  labelText: "Bairro",
                  labelStyle: TextStyle(
                  color: Colors.black38,
                  fontWeight: FontWeight.w400,
                  fontSize: 20,
                  ),
                ),
                style: TextStyle(fontSize: 20),
              ),
              SizedBox(
              height: 10,
              ),
              TextFormField(
                keyboardType: TextInputType.text,
                decoration: InputDecoration(
                  labelText: "Ponto de referência",
                  labelStyle: TextStyle(
                  color: Colors.black38,
                  fontWeight: FontWeight.w400,
                  fontSize: 20,
                  ),
                ),
                style: TextStyle(fontSize: 20),
              ),
              SizedBox(
              height: 10,
              ),
              TextFormField(
                keyboardType: TextInputType.text,
                decoration: InputDecoration(
                  labelText: "Caracteristicas adicionais do infrator",
                  labelStyle: TextStyle(
                  color: Colors.black38,
                  fontWeight: FontWeight.w400,
                  fontSize: 20,
                  ),
                ),
                style: TextStyle(fontSize: 20),
              ),
              SizedBox(
              height: 30,
            ),
            Container(
              height: 45,
              alignment: Alignment.centerLeft,
              decoration: BoxDecoration(
                gradient: LinearGradient(
                  begin: Alignment.topLeft,
                  end: Alignment.bottomRight,
                  stops: [0.3, 1],
                  colors: [
                    Color(0xFF2E7D32),
                    Color(0xFF66BB6A),
                  ],
                ),
                borderRadius: BorderRadius.all(
                  Radius.circular(5),
                ),
              ),
              child: SizedBox.expand(
                child: FlatButton(
                  child: Text(
                    "Enviar denúncia",
                    style: TextStyle(
                      fontWeight: FontWeight.bold,
                      color: Colors.white,
                      fontSize: 20,
                    ),
                    textAlign: TextAlign.center,
                  ),
                  onPressed: () => showDialog<String>(
                    context: context,
                    builder: (BuildContext context) => AlertDialog(
                      title: const Text('Denúncia'),
                      content: const Text('Sua denúncia foi enviada com sucesso'),
                      actions: <Widget>[
                        TextButton(
                          onPressed: () => Navigator.pop(context, 'Cancel'),
                          child: const Text('Cancel'),
                        ),
                        TextButton(
                          onPressed: () => Navigator.pop(context, 'OK'),
                          child: const Text('OK'),
                          ),
                        ],
                      ),
                    ),
                ),
              ),
            ),
            SizedBox(
              height: 30,
            ),
            ],
          ),
        ),
      );
  }

  _getImage() async {
    PickedFile imageFile = await picker.getImage(
      source: ImageSource.camera);

    if (imageFile == null) return;

    File tmpFile = File(imageFile.path);

    final appDir = await getApplicationDocumentsDirectory();
    final fileName = basename(imageFile.path);

    tmpFile = await tmpFile.copy('${appDir.path}/$fileName');
    print('File path is :${tmpFile.path}');

    setState(() {
      _image = tmpFile;
    });
  }

   _getImage1() async {
    PickedFile imageFile = await picker.getImage(
      source: ImageSource.gallery);

    if (imageFile == null) return;

    File tmpFile = File(imageFile.path);

    final appDir = await getApplicationDocumentsDirectory();
    final fileName = basename(imageFile.path);

    tmpFile = await tmpFile.copy('${appDir.path}/$fileName');
    print('File path is :${tmpFile.path}');

    setState(() {
      _image = tmpFile;
    });
  }

}
