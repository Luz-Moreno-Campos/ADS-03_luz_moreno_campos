

namespace ADS_03_luz_moreno_campos
{
    public class FileManager
    {
        private readonly string _vaultPath;
        private readonly string _summaryPath;

        public FileManager(string vaultPath, string summaryPath)
        {

            if (vaultPath == null)
            {
                throw new ArgumentNullException(
                    paramName: null,
                    message: "Vault file path cannot be null.");
            }

            if (vaultPath.Trim() == "")
            {
                throw new ArgumentException(
                    message: "Vault file path cannot be empty.",
                    paramName: null);
            }


            if (!File.Exists(vaultPath))
            {
                throw new FileNotFoundException(
                    message: "Vault file not found.",
                    fileName: vaultPath);
            }



            // Path.GetFullPath validates the path and, if it's valid, converts it to an absolute path; otherwise it throws an error.
            // It checks for invalid characters, unsupported path formats, and paths that are too long.
            // I use try catch here to catch the system exceptions from GetFullPath and throw my own custom messages to keep all path errors consistent.

            try
            {
                Path.GetFullPath(vaultPath);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException(
                    message: "Vault file path contains invalid characters or has an invalid format.",
                    paramName: null);

            }
            catch (NotSupportedException)
            {
                throw new NotSupportedException("Vault file path has an invalid format.");
            }
            catch (PathTooLongException)
            {
                throw new PathTooLongException("Vault file path exceeds the maximum allowed length.");
            }


            if (Directory.Exists(vaultPath))
            {
                throw new ArgumentException(
                    message: "Vault file path cannot be a directory.",
                    paramName: null);
            }


            if (summaryPath == null)
            {
                throw new ArgumentNullException(
                    paramName: null,
                    message: "Summary file path cannot be null.");
            }

            if (summaryPath.Trim() == "")
            {
                throw new ArgumentException(
                    message: "Summary file path cannot be empty.",
                    paramName: null);
            }

            if (!File.Exists(summaryPath))
            {
                throw new FileNotFoundException(
                    message: "Summary file not found.",
                    fileName: summaryPath);
            }

            try
            {
                Path.GetFullPath(summaryPath);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException(
                    message: "Summary file path contains invalid characters or has an invalid format.",
                    paramName: null);
            }
            catch (NotSupportedException)
            {
                throw new NotSupportedException("Summary file path has an invalid format.");
            }
            catch (PathTooLongException)
            {
                throw new PathTooLongException("Summary file path exceeds the maximum allowed length.");
            }

            if (Directory.Exists(summaryPath))
            {
                throw new ArgumentException(
                    message: "Summary file path cannot be a directory.",
                    paramName: null);
            }

            _vaultPath = vaultPath;
            _summaryPath = summaryPath;
        }


        private string[] ReadLinesFromFile(string filePath)
        {
            string[] lines;

            try
            {
                lines = File.ReadAllLines(filePath);
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException(
                    "Access denied while reading the vault file.");
            }
            catch (IOException)
            {
                throw new IOException(
                    "An I/O error occurred while reading the vault file.");
            }

            return lines;
        }

        private AlienArtifact[] CreateArtifactsFromLines(string[] lines, out int count)
        {
            AlienArtifact[] artifacts = new AlienArtifact[lines.Length];
            count = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                if (line == null || line == "" || line.Trim() == "")
                {
                    throw new FormatException(
                        $"Invalid line at index {i}: line is empty.");
                }

                string[] parts = line.Split('|');

                if (parts.Length != 5)
                {
                    throw new FormatException(
                        $"Invalid format at line {i + 1}. Valid format is 5 fields separated by '|'.");
                }

                string encodedName = parts[0].Trim();
                string planet = parts[1].Trim();
                string discoveryDate = parts[2].Trim();
                string storageLocation = parts[3].Trim();
                string description = parts[4].Trim();

                try
                {
                    AlienArtifact artifact = new AlienArtifact(
                        encodedName,
                        "",
                        planet,
                        discoveryDate,
                        storageLocation,
                        description);

                    artifacts[count] = artifact;
                    count++;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Error at line {i + 1}: {ex.Message}");
                }
            }

            return artifacts;
        }

        public AlienArtifact[] LoadVault(out int count)
        {
            string[] lines = ReadLinesFromFile(_vaultPath);
            return CreateArtifactsFromLines(lines, out count);
        }


        public void SaveSummary(AlienArtifact[] artifacts)
        {
            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter(_summaryPath);

                for (int i = 0; i < artifacts.Length; i++)
                {
                    AlienArtifact artifact = artifacts[i];

                    if (artifact == null)
                    {
                        throw new FormatException(
                            $"Invalid artifact at index {i}: artifact is null.");
                    }

                    string line =
                        $"{artifact.EncodedName}|{artifact.Planet}|{artifact.DiscoveryDate}|{artifact.StorageLocation}|{artifact.Description}";

                    writer.WriteLine(line);
                }
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException(
                    "Access denied while writing the summary file.");
            }
            catch (IOException)
            {
                throw new IOException(
                    "An I/O error occurred while writing the summary file.");
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
        public AlienArtifact LoadArtifactFile(string artifactPath)
        {
            string[] lines = ReadLinesFromFile(artifactPath);

            int count;

            AlienArtifact[] artifacts = CreateArtifactsFromLines(lines, out count);

            if (count != 1)
            {
                throw new FormatException("Artifact file must contain exactly one artifact line.");
            }

            return artifacts[0];
        }



    }
}