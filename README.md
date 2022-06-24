# tesseract-ocr-dotnet-linux-docker

Example how to run `tesseract` using .NET 6 and the library [`TesseractOCR`](https://github.com/Sicos1977/TesseractOCR) in a Docker container.

```shell
cd TeasseractOCROnLInux
./download-tessdata.sh # download english tessdata files
docker build . -t tesseractdotnet # build the container from Dockerfile
docker run -v $PWD/tessdata:/app/tessdata -v $PWD/in:/app/in tesseractdotnet # run container from image with volume mappings
```
