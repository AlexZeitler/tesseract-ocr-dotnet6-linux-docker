FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
RUN apt-get update -y && apt-get install -y libc6-dev libgdiplus libx11-dev libleptonica-dev software-properties-common wget gnupg2 libleptonica-dev
RUN apt-get update -y && apt-get install apt-transport-https -y
RUN tee /etc/apt/sources.list.d/notesalexp.list<<EOF
RUN echo "deb https://notesalexp.org/tesseract-ocr5/$(lsb_release -cs)/ $(lsb_release -cs) main" \
   | tee /etc/apt/sources.list.d/notesalexp.list > /dev/null
RUN wget -O - https://notesalexp.org/debian/alexp_key.asc | apt-key add - 
RUN apt-get update -y && apt-get install tesseract-ocr -y    
RUN ls -la /usr/lib/x86_64-linux-gnu
WORKDIR /app
COPY --from=build-env /app/out .
RUN ln -s /usr/lib/x86_64-linux-gnu/liblept.so.5 /app/x64/libleptonica-1.82.0.dll.so
RUN ln -s /usr/lib/x86_64-linux-gnu/libtesseract.so.5 /app/x64/libtesseract51.dll.so
ENTRYPOINT ["dotnet", "TeasseractOCROnLInux.dll"]